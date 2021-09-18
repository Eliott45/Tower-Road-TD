using Mouse;
using Pathfinding;
using UnityEngine;

namespace Units
{
    public abstract class Unit : MonoBehaviour, IClicked
    {
        [Header("Unit options: ")]
        [SerializeField] private float _health;
        [SerializeField] private float _physicalResistance;
        [SerializeField] private float _magicalResistance;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _attackSpeed;
        [SerializeField] private float _damage;
        [SerializeField] private float _triggerRange;
        [SerializeField] private EUnitMode _unitMode;
        [SerializeField] private ETypeDamage _damageType;

        private AIDestinationSetter _destinationSetter;
        private AIPath _aiPath;
        private Quaternion _transformRotation;
        
        private protected void Awake()
        {
            _destinationSetter = GetComponent<AIDestinationSetter>();
            _aiPath = GetComponent<AIPath>();
            _transformRotation = transform.rotation;
        }

        private protected void Start()
        {
            _aiPath.maxSpeed = _movementSpeed;
        }

        private void FixedUpdate()
        {
            switch (_unitMode)
            {
                case EUnitMode.Move:
                    _transformRotation.y = _aiPath.steeringTarget.x - transform.position.x <= 0 ? 180f : 0f;
                    transform.rotation = _transformRotation;
                    break;
            }
        }

        private protected abstract void Attack(GameObject target);
        private protected abstract void GetDamage(float damage);
        private protected abstract void Die();

        public void SetDestination(Transform destination)
        {
            _destinationSetter.target = destination;
            _unitMode = EUnitMode.Move;
        }

        public void OnClick()
        {
            Debug.Log("Unit click");
        }
    }
}
