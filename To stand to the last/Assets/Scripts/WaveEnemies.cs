using UnityEngine;

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
    public float secondToSpawnEnemy = 1.5f;
}