using System;
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

        public void SetMaxHealth(float hp)
        {
            _slider.maxValue = hp;
            _slider.value = hp;
        }

        public void SetCurrentHealth(float hp)
        {
            _slider.value = hp;
        }
    }
}
