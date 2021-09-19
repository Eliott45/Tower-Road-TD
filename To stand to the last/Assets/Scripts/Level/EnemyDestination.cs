using Units;
using UnityEngine;

namespace Level
{
    public class EnemyDestination : MonoBehaviour
    {
        [Header("Set in Inspector")] 
        [SerializeField] private Player _player;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Enemy")) return; // If not the enemy, get out 
            _player.GetDamage(other.GetComponent<Enemy>().damageToPlayer);
            Destroy(other.gameObject); // Destroy the enemy 
        }
    }
}
