using UnityEngine;

namespace Units
{
    public class Hero : Unit
    {
        [Header("Set hero options:")] 
        [SerializeField] private int _level;
        [SerializeField] private float _experience;
        
        private protected override void Attack(GameObject target) {}
        private protected override void GetDamage(float damage) {}
        private protected override void Move(Vector3 pos) {}
        private protected override void Die() {}
        
        private void GetExp(float exp) {}
        private void LevelUp(){}
    }
}
