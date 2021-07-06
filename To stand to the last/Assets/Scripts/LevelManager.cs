using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Set in Inspector")] 
    [SerializeField] private GameObject losingUI;
    [SerializeField] private GameObject winUI;

    /// <summary>
    /// Displays the lose window, and freezes the time.
    /// </summary>
    public void LoseGame()
    {
        losingUI.SetActive(true);
        Time.timeScale = 0;
    }
    
    /// <summary>
    /// Displays the win window, and freezes the time.
    /// </summary>
    public void WinGame()
    {
        winUI.SetActive(true);
        Time.timeScale = 0;
    }
    
}
