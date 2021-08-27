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

        private protected abstract void Attack(GameObject target);
        private protected abstract void GetDamage(float damage);
        private protected abstract void Move(Vector3 pos);
        private protected abstract void Die();
        
        public void OnClick() { }
    }
}
