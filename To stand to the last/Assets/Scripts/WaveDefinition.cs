[System.Serializable]
public class WaveDefinition
{
    /// <summary>
    /// The amount of time until the wave spawn.
    /// </summary>
    public float secondToSpawnWave = 60f;
    public WaveEnemies[] enemies;
}