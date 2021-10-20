using TMPro;
using UnityEngine;

namespace Level
{
    /// <summary>
    /// Component for displaying player data.
    /// </summary>
    public class UIPlayerStats : MonoBehaviour
    {
        public static UIPlayerStats instance;
        
        [Header("Set in Inspector:")] 
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _goldText;

        private void Awake()
        {
            instance = this;
        }

        public void UpdateHealthCounter(int health)
        {
            _healthText.text = health.ToString();
        }
        
        public void UpdateGoldCounter(int gold)
        {
            _goldText.text = gold.ToString();
        }
        
    }
}
