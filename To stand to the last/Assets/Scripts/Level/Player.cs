using System;
using UnityEngine;

namespace Level
{
    public class Player : MonoBehaviour
    {
        [Header("Set in Inspector:")]
        [SerializeField] private UIPlayerStats _UIPlayerStats;
        
        [Header("Set player options: ")] 
        [SerializeField] private int _health;
        [SerializeField] private int _gold;

        private void Awake()
        {
            _UIPlayerStats.UpdateHealthCounter(_health);
            _UIPlayerStats.UpdateGoldCounter(_gold);
        }

        public void GetDamage(int damage)
        {
            _health -= damage;
            _UIPlayerStats.UpdateHealthCounter(_health);
        }

        private void GetGold(int gold)
        {
        
        }

        private void SpendGold(int gold)
        {
        
        }
    }
}
