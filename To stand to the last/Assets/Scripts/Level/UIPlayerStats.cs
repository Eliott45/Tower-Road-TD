using TMPro;
using UnityEngine;

namespace Level
{
    public class UIPlayerStats : MonoBehaviour
    {
        [Header("Set in Inspector:")] 
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _goldText;

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
