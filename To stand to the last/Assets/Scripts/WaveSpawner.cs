using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    /// <summary>
    /// Spawn location of opponents.
    /// </summary>
    [Header("Set in Inspector")]
    [SerializeField] private Transform origin;
    /// <summary>
    /// End point of arrival for enemies.
    /// </summary>
    [SerializeField] private Transform destination;
    
    [Header("Waves options:")]
    [SerializeField] private WaveDefinition[] waves;
    
    private UIDisplayStats _wavesUI;
    private LevelManager _levelManager;
    private int _currentWave;
    private readonly List<GameObject> _enemies = new List<GameObject>(); 
    
    private static Transform _enemyAnchorTransform;


    private void Awake()
    {
        _enemyAnchorTransform = new GameObject("EnemyAnchor").transform;
        
        if (Camera.main is null) return;
        _wavesUI = Camera.main.GetComponent<UIDisplayStats>();
        _levelManager = Camera.main.GetComponent<LevelManager>();
    }

    private void Start()
    {
        _wavesUI.UpdateWaveCounter(_currentWave, waves.Length);
        StartCoroutine(SpawnWave());
    }

    private void LateUpdate()
    {
        _enemies.RemoveAll( x => !x);

        if (_enemies.Count == 0 && _currentWave == waves.Length)
        {
            _levelManager.WinGame();
        }
    }

    /// <summary>
    /// Start spawning waves.
    /// </summary>
    private IEnumerator SpawnWave()
    {
        // Waiting for the time until the new wave 
        yield return new WaitForSeconds(waves[_currentWave].secondToSpawnWave);
        
        _currentWave++;
        _wavesUI.UpdateWaveCounter(_currentWave, waves.Length);
        
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

    /// <summary>
    /// Spawn an enemy.
    /// </summary>
    /// <param name="enemy">Enemy prefab.</param>
    private void SpawnEnemy(GameObject enemy)
    {
        var go = Instantiate(enemy, origin);
        _enemies.Add(go);
        go.transform.parent = _enemyAnchorTransform;
        go.GetComponent<NavMeshAgent2D>().destination = destination.position;
    }
}
