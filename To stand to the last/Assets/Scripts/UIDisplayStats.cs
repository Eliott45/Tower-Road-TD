using UnityEngine;
using UnityEngine.UI;

public class UIDisplayStats : MonoBehaviour
{
    [Header("Set in Inspector:")] 
    [SerializeField] private Text _healthCounter;
    [SerializeField] private Text _goldCounter;
    [SerializeField] private Text _waveCounter;
    
    /// <summary>
    /// Maximum allowed number of skipped enemies.
    /// </summary>
    [Header("Set Options:")]
    public int health = 20;
    
    public void UpdateHealthCounter(int damage = 1)
    {
        health -= damage;
        
        if(health <= 0)
        {
            GetComponent<LevelManager>().LoseGame();
        }
        
        _healthCounter.text = health.ToString();
    }

    /// <summary>
    /// Change text of wave in UI.
    /// </summary>
    /// <param name="currentWave">Current wave in a level.</param>
    /// <param name="maxWaves">Maximum number of waves in a level.</param>
    public void UpdateWaveCounter(int currentWave, int maxWaves)
    {
        _waveCounter.text = $"WAVE {currentWave} / {maxWaves}";
    }
}
