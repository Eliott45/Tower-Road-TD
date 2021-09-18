using UnityEngine;

namespace Level
{
    public class EnemyDestination : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Enemy")) return; // If not the enemy, get out 
            Destroy(other.gameObject); // Destroy the enemy 
        }
    }
}
