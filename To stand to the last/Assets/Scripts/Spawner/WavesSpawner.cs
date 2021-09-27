using System.Collections;
using System.Collections.Generic;
using Level;
using Units;
using UnityEngine;

namespace Spawner
{
    /// <summary>
    /// Component for spawning enemy waves.
    /// </summary>
    public class WavesSpawner : MonoBehaviour
    {
        [Header("Set in Inspector:")] 
        [SerializeField] private UIWaveCounter _waveCounterUI;

        [Header("Set spawn options:")]
        [SerializeField] private Transform _origin; // Spawn point 
        [SerializeField] private Transform _destination; // enemy destination

        [Header("Set waves options:")]
        [SerializeField] private Wave[] _waves;

        private int _currentWave;
        private Transform _enemyAnchorTransform; // Anchor for enemies (for easy display in the editor) 
        private readonly List<GameObject> _enemiesList = new List<GameObject>(); // List of enemies in the game scene
        
        private void Awake()
        {
            _enemyAnchorTransform = new GameObject("EnemyAnchor").transform;
        }

        private void Start()
        {
            StartCoroutine(SpawnWave());
        }

        /// <summary>
        /// Spawn wave.
        /// </summary>
        private IEnumerator SpawnWave()
        {
            yield return new WaitForSeconds(_waves[_currentWave].timeBeforeSpawnWave); 
            
            _currentWave++;
            _waveCounterUI.UpdateWaveCounter(_currentWave, _waves.Length);
            
            if (_currentWave < _waves.Length) StartCoroutine(SpawnWave());
            
            var enemies = _waves[_currentWave - 1].enemies;
            foreach (var enemy in enemies)
            {
                for (var j = 0; j < enemy.count; j++)
                {
                    SpawnEnemy(enemy.enemyPrefab);
                    yield return new WaitForSeconds(_waves[_currentWave -1].timeBeforeSpawnEnemy);
                }
            }

            if (_currentWave != _waves.Length) yield break;
            _enemiesList.RemoveAll(x => !x);
            StartCoroutine(CheckEnemies(_enemiesList));
        }
        
        /// <summary>
        /// Create enemy.
        /// </summary>
        /// <param name="enemy">Enemy prefab.</param>
        private void SpawnEnemy(GameObject enemy)
        {
            var go = Instantiate(enemy, _enemyAnchorTransform);
            go.transform.position = _origin.position;
            go.GetComponent<Enemy>().SetDestination(_destination);
            _enemiesList.Add(go);
        }
        
        private IEnumerator CheckEnemies(List<GameObject> enemies)
        {
            yield return new WaitForSeconds(3f);
            enemies.RemoveAll(x => !x);
            if (enemies.Count == 0)
            {
                LevelManager.instance.Win();
            }
            else
            {
                StartCoroutine(CheckEnemies(enemies));
            }
        }
    }
}
