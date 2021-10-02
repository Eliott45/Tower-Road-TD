using System;
using UnityEngine;

namespace Level
{
    /// <summary>
    /// The main player.
    /// </summary>
    [RequireComponent(typeof(LevelManager))]
    public class Player : MonoBehaviour
    {
        public static Player instance;

        [Header("Set player options: ")] 
        [SerializeField] private int _health;
        [SerializeField] private int _gold;

        private UIPlayerStats _playerStats; // Component for displaying player data (UI)
        
        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            _playerStats = UIPlayerStats.instance;
            _playerStats.UpdateHealthCounter(_health);
            _playerStats.UpdateGoldCounter(_gold);
        }

        public void GetDamage(int damage)
        {
            _health -= damage;
            _playerStats.UpdateHealthCounter(_health);
            if (_health <= 0) LevelManager.instance.Lose();
        }
        
        public int GetGold()
        {
            return _gold;
        }

        private void AddGold(int gold)
        {
        
        }
        
        public void SpentGold(int gold)
        {
            _gold -= gold;
            _playerStats.UpdateGoldCounter(_gold);
        }
    }
}
