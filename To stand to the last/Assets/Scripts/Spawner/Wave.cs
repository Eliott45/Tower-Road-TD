namespace Spawner
{
    /// <summary>
    /// Component containing information about the wave for its spawn.
    /// </summary>
    [System.Serializable]
    public class Wave
    {
        /// <summary>
        /// Spawn a wave in n-time.
        /// </summary>
        public float spawnWaveTime;
        /// <summary>
        /// Spawn an enemy in n-time.
        /// </summary>
        public float enemyPerSecond;
        /// <summary>
        /// Enemy groups.
        /// </summary>
        public Enemies[] enemies;
    }
}
