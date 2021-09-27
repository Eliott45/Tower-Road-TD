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

        private UIPlayerStats _playerStats;
        
        private void Start()
        {
            instance = this;
            _playerStats = UIPlayerStats.instance;
            UIPlayerStats.instance.UpdateHealthCounter(_health);
            UIPlayerStats.instance.UpdateGoldCounter(_gold);
        }

        public void GetDamage(int damage)
        {
            _health -= damage;
            UIPlayerStats.instance.UpdateHealthCounter(_health);
            if (_health <= 0) LevelManager.instance.Lose();
        }

        private void GetGold(int gold)
        {
        
        }

        private void SpendGold(int gold)
        {
        
        }
    }
}
