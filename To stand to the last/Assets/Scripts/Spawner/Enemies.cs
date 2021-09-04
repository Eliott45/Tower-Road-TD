using UnityEngine;

namespace Spawner
{
    /// <summary>
    /// Component containing information about the enemy to spawn.
    /// </summary>
    [System.Serializable]
    public class Enemies
    {
        /// <summary>
        /// Enemy prefab.
        /// </summary>
        public GameObject enemyPrefab;
        /// <summary>
        /// Spawn amount of this enemy.
        /// </summary>
        public int count;
    }
}
