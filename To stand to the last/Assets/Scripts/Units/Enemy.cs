using UnityEngine;

namespace Units
{
    public class Enemy : Unit
    {
        [Header("Set enemy options:")] 
        [SerializeField] private Transform _destination;
        [SerializeField] private int _damageToPlayer;
        [SerializeField] private int _goldReward;
        [SerializeField] private float _expReward;
        
        private protected override void Attack(GameObject target) { }
        private protected override void GetDamage(float damage) { }
        private protected override void Move(Vector3 pos) { }
        private protected override void Die() { }
        
        private void GetDestination(Transform destination)
        {
            _destination = destination;
        }
    }
}
