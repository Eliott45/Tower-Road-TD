using System.Linq;
using Mouse;
using Pathfinding;
using UnityEngine;

namespace Units
{
    [RequireComponent(typeof(AIPath))]
    [RequireComponent(typeof(AIDestinationSetter))]
    [RequireComponent(typeof(Animator))]
    public abstract class Unit : MonoBehaviour, IClicked
    {
        [Header("Unit options: ")]
        [SerializeField] private float _health; // Current health of unit
        [SerializeField] private float _physicalResistance;
        [SerializeField] private float _magicalResistance;
        [SerializeField] private float _movementSpeed; // Unit movement speed 
        [SerializeField] private float _attackSpeed;
        [SerializeField] private float _damage;
        [SerializeField] private float _showDamageDuration = 0.1f;
        [SerializeField] private float _triggerRange;
        [SerializeField] private EUnitMode _unitMode;
        [SerializeField] private ETypeDamage _damageType;
        [SerializeField] private HealthBar _healthBar;

        // Moving unit
        private AIDestinationSetter _destinationSetter;
        private AIPath _aiPath;
        private Quaternion _transformRotation;
        
        // Visual damage unit
        private Color[] _originalColors;
        private Material[] _materials;
        private float _damageDoneTime;
        private bool _showingDamage;

        // Animations
        private Animator _animator;
        private static readonly int Alive = Animator.StringToHash("alive");
        private static readonly int Demolish = Animator.StringToHash("demolish");

        private protected void Awake()
        {
            _animator = GetComponent<Animator>();
            
            // variables for moving Agent
            _destinationSetter = GetComponent<AIDestinationSetter>();
            _aiPath = GetComponent<AIPath>();
            _transformRotation = transform.rotation;
            
            // Materials for visual damage
            _materials = GetAllMaterials(gameObject);
            _originalColors = new Color[_materials.Length];
            for (var i = 0; i < _materials.Length; i++){
                _originalColors[i] = _materials[i].color;
            }
            
            // HealthBar
            _healthBar.SetMaxHealth(_health);
        }

        private protected void Start()
        {
            _aiPath.maxSpeed = _movementSpeed;
        }

        private void Update()
        {
            if (_showingDamage && Time.time > _damageDoneTime) {
                UnShowDamage();
            }
        }
        
        private void FixedUpdate()
        {
            switch (_unitMode)
            {
                case EUnitMode.Move:
                    _transformRotation.y = _aiPath.steeringTarget.x - transform.position.x <= 0 ? 180f : 0f;
                    transform.rotation = _transformRotation;
                    break;
                case EUnitMode.Die:
                    _aiPath.maxSpeed = 0;
                    _animator.SetBool(Alive, false);
                    if(_animator.GetBool(Demolish)) Destroy(gameObject); // If the death animation played, destroy the object
                    break;
            }
        }

        private protected abstract void Attack(GameObject target);

        internal virtual void GetDamage(float damage, ETypeDamage typeDamage)
        {
            ShowDamage();
            
            // Calculate damage taking into account resistance 
            damage = typeDamage == ETypeDamage.Physical ? damage - _physicalResistance : damage - _magicalResistance; 
            
            _health -= damage;
            _healthBar.SetCurrentHealth(_health);
            if (_health <= 0 && _unitMode != EUnitMode.Die) Die();
        }

        public virtual void Die()
        {
            _unitMode = EUnitMode.Die;
        }

        public void SetDestination(Transform destination)
        {
            _destinationSetter.target = destination;
            _unitMode = EUnitMode.Move;
        }
    
        public void OnClick()
        {
            Debug.Log("Unit click");
        }
        
        /// <summary>
        /// Retrieving all materials of an object.
        /// </summary>
        /// <param name="go">Game object.</param>
        /// <returns>List of materials.</returns>
        private static Material[] GetAllMaterials(GameObject go) {
            var rends = go.GetComponentsInChildren<Renderer>();
            return(rends.Select(rend => rend.material).ToArray());
        }
        
        /// <summary>
        /// Make unit red to show damage. 
        /// </summary>
        private void ShowDamage() {
            foreach (var m in _materials) {
                m.color = Color.red;
            }
            _showingDamage = true;
            _damageDoneTime = Time.time + _showDamageDuration;
        }
    
        /// <summary>
        /// Make unit color normal to unshow damage.
        /// </summary>
        private void UnShowDamage() {
            for (var i = 0; i < _materials.Length; i++) {
                _materials[i].color = _originalColors[i];
            }
            _showingDamage = false;
        }
    }
}
