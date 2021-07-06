using System;
using UnityEngine;

public class EnemyDestination : MonoBehaviour
{
    private UIDisplayStats _stats;

    private void Awake()
    {
        if (Camera.main is { }) _stats = Camera.main.GetComponent<UIDisplayStats>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;
        _stats.UpdateHealthCounter();
        Destroy(other.gameObject); // Destroy the enemy 
    }
}
