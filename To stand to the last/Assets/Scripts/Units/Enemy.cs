using Spawner;
using UnityEngine;

namespace Units
{
    public class Enemy : Unit
    {
        [Header("Set enemy options:")]
        public int damageToPlayer;
        [SerializeField] private int _goldReward;
        [SerializeField] private float _expReward;

        private protected override void Attack(GameObject target) { }

        internal override void GetDamage(float damage)
        {
            Debug.LogError("Get damage: " + damage);
            base.GetDamage(damage);
        }

        public override void Die()
        {
            Destroy(gameObject);
            WavesSpawner.instance.CheckEnemies(); 
        }
        
    }
}
