using UnityEngine;

[System.Serializable]
public class WaveEnemies
{
    /// <summary>
    /// Enemy type.
    /// </summary>
    public GameObject typeOfEnemy;
    public int count;
    public float secondToSpawnEnemy = 1.5f;
}