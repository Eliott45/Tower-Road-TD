using UnityEngine;

/// <summary>
/// Data on the wave of enemies. 
/// </summary>
[System.Serializable]
public class WaveEnemies
{
    /// <summary>
    /// Enemy prefab.
    /// </summary>
    public GameObject typeOfEnemy;
    /// <summary>
    /// The number of enemy of this type. 
    /// </summary>
    public int count;
    /// <summary>
    /// The number of seconds to spawn one enemy. 
    /// </summary>
    public float secondToSpawnEnemy = 1.5f;
}