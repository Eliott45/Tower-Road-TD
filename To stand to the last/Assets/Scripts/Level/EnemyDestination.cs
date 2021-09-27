using Units;
using UnityEngine;

namespace Level
{
    public class EnemyDestination : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Enemy")) return; // If not the enemy, get out 
            Player.instance.GetDamage(other.GetComponent<Enemy>().damageToPlayer);
            Destroy(other.gameObject); // Destroy the enemy 
        }
    }
}
