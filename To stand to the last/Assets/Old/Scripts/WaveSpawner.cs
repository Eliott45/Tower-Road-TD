using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Old.Scripts
{
    public class WaveSpawner : MonoBehaviour
    {
        /// <summary>
        /// Spawn location of opponents.
        /// </summary>
        [Header("Set in Inspector")]
        [SerializeField] private Transform _origin;
        /// <summary>
        /// End point of arrival for enemies.
        /// </summary>
        [SerializeField] private Transform _destination;
    
        [Header("Waves options:")]
        [SerializeField] private WaveDefinition[] _waves;
    
        private UIDisplayStats _wavesUI;
        private global::LevelManager _levelManager;
        private int _currentWave;
        private readonly List<GameObject> _enemies = new List<GameObject>(); 
    
        private static Transform _enemyAnchorTransform;


        private void Awake()
        {
            // Create an empty object to store enemies in the scene 
            _enemyAnchorTransform = new GameObject("EnemyAnchor").transform;
        
            if (Camera.main is null) return;
            _wavesUI = Camera.main.GetComponent<UIDisplayStats>();
            _levelManager = Camera.main.GetComponent<global::LevelManager>();
        }

        private void Start()
        {
            _wavesUI.UpdateWaveCounter(_currentWave, _waves.Length);
            StartCoroutine(SpawnWave());
        }

        private void LateUpdate()
        {
            _enemies.RemoveAll( x => !x);

            if (_enemies.Count == 0 && _currentWave == _waves.Length)
            {
                // _levelManager.WinGame();
            }
        }

        /// <summary>
        /// Start spawning waves.
        /// </summary>
        private IEnumerator SpawnWave()
        {
            // Waiting for the time until the new wave 
            yield return new WaitForSeconds(_waves[_currentWave].secondToSpawnWave);
        
            _currentWave++;
            _wavesUI.UpdateWaveCounter(_currentWave, _waves.Length);
        
            if (_currentWave < _waves.Length) StartCoroutine(SpawnWave());

            var enemies = _waves[_currentWave - 1].enemies;

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
            var go = Instantiate(enemy, _origin);
            _enemies.Add(go);
            go.transform.parent = _enemyAnchorTransform;
            go.GetComponent<NavMeshAgent2D>().destination = _destination.position;
        }
    }
}
