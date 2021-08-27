/// <summary>
/// Wave data.
/// </summary>
[System.Serializable]
public class WaveDefinition
{
    /// <summary>
    /// The amount of time until the wave spawn.
    /// </summary>
    public float secondToSpawnWave = 60f;
    /// <summary>
    /// All waves of opponents are at the level. 
    /// </summary>
    public WaveEnemies[] enemies;
}