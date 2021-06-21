using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private GameObject guiBuildPanelPrefab;
    
    /// <summary>
    /// Main camera on scene.
    /// </summary>
    private Camera _camera;
    private GameObject _buildPanel;

    private void Awake()
    {
        _camera = Camera.main; 
    }

    private void Start()
    {
        if (guiBuildPanelPrefab == null) throw new Exception("Build panel prefab not installed!");
        _buildPanel = Instantiate(guiBuildPanelPrefab);
        _buildPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) StartCheck();
    }

    private void StartCheck()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit))
        {
            _buildPanel.SetActive(false);
            return;
        }

        switch (hit.collider.tag)
        {
            case "TowerSpot":
                _buildPanel.transform.position = hit.transform.position;
                _buildPanel.SetActive(true);
                break;
            default:
                break;
        }
    }
}
    