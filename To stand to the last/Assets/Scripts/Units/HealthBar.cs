using UnityEngine;
using UnityEngine.UI;

namespace Units
{
    /// <summary>
    /// Component responsible for showing the health of the unit. 
    /// </summary>
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private void Awake()
        {
            _slider.gameObject.SetActive(false);
        }

        /// <summary>
        /// Set max value in Slider.
        /// </summary>
        /// <param name="hp">Max value.</param>
        public void SetMaxHealth(float hp)
        {
            _slider.maxValue = hp;
            _slider.value = hp;
        }

        public void SetCurrentHealth(float hp)
        {
            if (hp < _slider.maxValue) _slider.gameObject.SetActive(true);
            _slider.value = hp;
        }
    }
}
