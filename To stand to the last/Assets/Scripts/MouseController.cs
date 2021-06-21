using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [Header("Set GUI")]
    [SerializeField] private GameObject guiBuildPanelPrefab;

    [Header("Prefabs of towers")] 
    [SerializeField] private GameObject towerArcherPrefab;

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
                _buildPanel.transform.parent = hit.transform;
                _buildPanel.SetActive(true);
                break;
            case "BuildArcherTower":
                Instantiate(towerArcherPrefab);
                break;
            case "BuildMagicTower":
                Debug.Log("BuildMagicTower");
                break;
            case "BuildSupportTower":
                Debug.Log("BuildSupportTower");
                break;
            case "BuildStoneTower":
                Debug.Log("BuildStoneTower");
                break;
            default:
                _buildPanel.SetActive(false);
                break;
        }
    }
}
    