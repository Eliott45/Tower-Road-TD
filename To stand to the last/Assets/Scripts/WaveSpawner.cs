using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private Transform destination;
    
    [Header("Waves options:")]
    [SerializeField] private WaveDefinition[] waves;
    
    private int _currentWave;
    
    private static Transform _enemyAnchorTransform;
    
    private void Awake()
    {
        _enemyAnchorTransform = new GameObject("EnemyAnchor").transform;
    }

    private void Start()
    { 
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        // Waiting for the time until the new wave 
        yield return new WaitForSeconds(waves[_currentWave].secondToSpawnWave);
        
        _currentWave++;

        if (_currentWave < waves.Length) StartCoroutine(SpawnWave());

        var enemies = waves[_currentWave - 1].enemies;

        foreach (var enemy in enemies)
        {
            for (var j = 0; j < enemy.count; j++)
            {
                SpawnEnemy(enemy.typeOfEnemy);
                yield return new WaitForSeconds(enemy.secondToSpawnEnemy);
            }
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        var go = Instantiate(enemy, transform);
        go.transform.parent = _enemyAnchorTransform;
        go.GetComponent<NavMeshAgent2D>().destination = destination.position;
    }
}
