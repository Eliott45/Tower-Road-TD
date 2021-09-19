using UnityEngine;

namespace Level
{
    public class Player : MonoBehaviour
    {
        [Header("Set player options: ")] 
        [SerializeField] private float _health;
        [SerializeField] private int _gold;

        public void GetDamage(int damage)
        {
            _health -= damage;
        }

        private void GetGold(int gold)
        {
        
        }

        private void SpendGold(int gold)
        {
        
        }
    }
}
