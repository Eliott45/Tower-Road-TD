using UnityEngine;
using UnityEngine.UI;

public class UIDisplayStats : MonoBehaviour
{
    [Header("Set in Inspector:")] 
    [SerializeField] private Text healthCounter;
    [SerializeField] private Text goldCounter;
    [SerializeField] private Text waveCounter;
    

    [Header("Set Options:")] 
    public int health = 20;
    
    public void UpdateHealthCounter(int damage = 1)
    {
        health -= damage;
        
        if(health <= 0)
        {
            GetComponent<LevelManager>().LoseGame();
        }
        
        healthCounter.text = health.ToString();
    }

    public void UpdateWaveCounter(int currentWave, int maxWaves)
    {
        waveCounter.text = $"WAVE {currentWave} / {maxWaves}";
    }
}
