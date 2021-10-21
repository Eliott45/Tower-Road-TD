using UnityEngine;

namespace Units
{
    public class Hero : Unit
    {
        [Header("Set hero options:")] 
        [SerializeField] private int _level;
        [SerializeField] private float _experience;
        
        private protected override void Attack(GameObject target) {}
        internal override void GetDamage(float damage, ETypeDamage typeDamage) {}
        public override void Die() {}
        
        private void GetExp(float exp) {}
        private void LevelUp(){}
    }
}
