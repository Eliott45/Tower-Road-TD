using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Set in Inspector")] 
    [SerializeField] private GameObject losingUI;

    public void LoseGame()
    {
        losingUI.SetActive(true);
        Time.timeScale = 0;
    }
}
