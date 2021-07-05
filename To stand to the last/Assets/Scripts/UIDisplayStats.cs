using UnityEngine;
using UnityEngine.UI;

public class UIDisplayStats : MonoBehaviour
{
    [Header("Set in Inspector:")] 
    [SerializeField] private Text healthCounter;
    [SerializeField] private Text goldCounter;

    [Header("Set Options:")] 
    public int health = 20;
    
    private void Update()
    {
        healthCounter.text = health.ToString();
    }
    
    public void GetDamage(int damage = 1)
    {
        health -= damage;
        if(health <= 0)
        {
            GetComponent<LevelManager>().LoseGame();
        }
    }
}
