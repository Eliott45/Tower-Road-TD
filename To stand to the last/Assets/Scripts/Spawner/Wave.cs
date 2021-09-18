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
        public float timeBeforeSpawnWave;
        /// <summary>
        /// Spawn an enemy in n-time.
        /// </summary>
        public float timeBeforeSpawnEnemy;
        /// <summary>
        /// Enemy groups.
        /// </summary>
        public Enemies[] enemies;
    }
}
