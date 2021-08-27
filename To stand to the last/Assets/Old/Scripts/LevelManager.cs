using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Set in Inspector")] 
    [SerializeField] private GameObject _losingUI;
    [SerializeField] private GameObject _winUI;

    /// <summary>
    /// Displays the lose window, and freezes the time.
    /// </summary>
    public void LoseGame()
    {
        _losingUI.SetActive(true);
        Time.timeScale = 0; // Stop all updates in the game 
    }
    
    /// <summary>
    /// Displays the win window, and freezes the time.
    /// </summary>
    public void WinGame()
    {
        _winUI.SetActive(true);
        Time.timeScale = 0;
    }
    
}
