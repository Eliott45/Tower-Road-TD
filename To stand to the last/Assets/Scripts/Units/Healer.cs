using UnityEngine;

namespace Units
{
    public class Healer : Enemy
    {
        [Header("Set healer options:")] 
        [SerializeField] private float _recoverySpeed;
        [SerializeField] private float _recoveryHealth;
        [SerializeField] private float _recoveryRange;
        
        private void Heal(GameObject target) { }
    }
}
