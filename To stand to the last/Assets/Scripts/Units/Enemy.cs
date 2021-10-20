using Level;
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
        
        public override void Die()
        {
            Player.instance.AddGold(_goldReward);
            WavesSpawner.instance.CheckEnemies(); 
            base.Die();
        }
        
    }
}
