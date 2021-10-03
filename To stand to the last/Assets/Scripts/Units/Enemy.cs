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
        private protected override void GetDamage(float damage) { }

        public override void Die()
        {
            Destroy(gameObject);
            WavesSpawner.instance.CheckEnemies(); 
        }
        
    }
}
