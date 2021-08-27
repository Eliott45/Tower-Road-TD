using UnityEngine;

namespace Units
{
    public class Defender : Unit
    {
        [Header("Set defender options")] 
        [SerializeField] private Transform position;
        
        private protected override void Attack(GameObject target) {}
        private protected override void GetDamage(float damage) {}
        private protected override void Move(Vector3 pos) {}
        private protected override void Die() {}
        
        private void Back(){}
    }
}
