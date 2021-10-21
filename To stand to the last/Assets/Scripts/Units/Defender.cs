using UnityEngine;

namespace Units
{
    public class Defender : Unit
    {
        [Header("Set defender options")] 
        [SerializeField] private Transform position;
        
        private protected override void Attack(GameObject target) {}
        internal override void GetDamage(float damage, ETypeDamage typeDamage) {}
        public override void Die() {}
        
        private void Back(){}
    }
}
