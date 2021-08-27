using System;
using UnityEngine;

/// <summary>
/// The final destination of enemies.
/// </summary>
public class EnemyDestination : MonoBehaviour
{
    private UIDisplayStats _stats;

    private void Awake()
    {
        if (Camera.main is { }) _stats = Camera.main.GetComponent<UIDisplayStats>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return; // If not the enemy, get out 
        _stats.UpdateHealthCounter(); 
        Destroy(other.gameObject); // Destroy the enemy 
    }
}
