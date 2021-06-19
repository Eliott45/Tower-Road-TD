using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private GameObject guiBuildChoice;
    
    private Camera _camera;
    
    private void Awake()
    {
        _camera = Camera.main; 
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) StartCheck();
    }

    private void StartCheck()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit)) return;

        switch (hit.collider.tag)
        {
            case "TowerSpot":
                Debug.Log("TowerPlace");
                break;
            default:
                break;
        }
    }
}
    