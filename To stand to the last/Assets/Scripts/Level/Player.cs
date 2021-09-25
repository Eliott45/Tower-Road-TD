using UnityEngine;

namespace Level
{
    /// <summary>
    /// The main player.
    /// </summary>
    [RequireComponent(typeof(LevelManager))]
    public class Player : MonoBehaviour
    {
        [Header("Set in Inspector:")]
        [SerializeField] private UIPlayerStats _UIPlayerStats;
        
        [Header("Set player options: ")] 
        [SerializeField] private int _health;
        [SerializeField] private int _gold;

        private LevelManager _levelManager;
        
        private void Awake()
        {
            _UIPlayerStats.UpdateHealthCounter(_health);
            _UIPlayerStats.UpdateGoldCounter(_gold);
            _levelManager = GetComponent<LevelManager>();
        }

        public void GetDamage(int damage)
        {
            _health -= damage;
            _UIPlayerStats.UpdateHealthCounter(_health);
            if (_health <= 0) _levelManager.Lose();
        }

        private void GetGold(int gold)
        {
        
        }

        private void SpendGold(int gold)
        {
        
        }
    }
}
