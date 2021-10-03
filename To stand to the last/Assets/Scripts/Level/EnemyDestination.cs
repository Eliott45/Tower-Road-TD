using Units;
using UnityEngine;

namespace Level
{
    public class EnemyDestination : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Enemy")) return; // If not the enemy, get out 
            var enemy = other.GetComponent<Enemy>();
            Player.instance.GetDamage(enemy.damageToPlayer);
            enemy.Die(); // Die enemy
        }
    }
}
