using System.Collections;
using Units;
using UnityEngine;

namespace Spawner
{
    /// <summary>
    /// Component for spawning enemy waves.
    /// </summary>
    public class WavesSpawner : MonoBehaviour
    {
        [Header("Set spawn options:")]
        [SerializeField] private Transform _origin; // Spawn point 
        [SerializeField] private Transform _destination; // enemy destination 
        
        [Header("Ser waves options:")]
        [SerializeField] private Wave[] _waves;

        private int _currentWave; 
        
        private void Start()
        {
            StartCoroutine(SpawnWave());
        }

        /// <summary>
        /// Spawn wave.
        /// </summary>
        private IEnumerator SpawnWave()
        {
            yield return new WaitForSeconds(_waves[_currentWave].spawnWaveTime); 
            
            _currentWave++;
            
            if (_currentWave < _waves.Length) StartCoroutine(SpawnWave());
            
            var enemies = _waves[_currentWave - 1].enemies;
            foreach (var enemy in enemies)
            {
                for (var j = 0; j < enemy.count; j++)
                {
                    SpawnEnemy(enemy.enemyPrefab);
                    yield return new WaitForSeconds(_waves[_currentWave -1].enemyPerSecond);
                }
            }
        }
        
        /// <summary>
        /// Create enemy.
        /// </summary>
        /// <param name="enemy">Enemy prefab.</param>
        private void SpawnEnemy(GameObject enemy)
        {
            var go = Instantiate(enemy, _origin);
            go.GetComponent<Enemy>().GetDestination(_destination);
        }
    }
}
