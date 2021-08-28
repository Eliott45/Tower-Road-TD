using System;
using Old.Scripts;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [Header("Set GUI")]
    [SerializeField] private GameObject _guiBuildPanelPrefab;

    [Header("Prefabs of towers")]
    [SerializeField] private GameObject _towerArcherPrefab;
    [SerializeField] private GameObject _towerSupportPrefab;
    [SerializeField] private GameObject _towerMagicPrefab;
    
    
    /// <summary>
    /// Main camera on scene.
    /// </summary>
    private Camera _camera;
    /// <summary>
    /// Graphic panel for construction.
    /// </summary>
    private GameObject _buildPanel;
    /// <summary>
    /// Empty game object for storing towers. 
    /// </summary>
    private static Transform _towerAnchorTransform;
    private UIDisplayStats _stats;

    private void Awake()
    {
        _camera = Camera.main; // Get main camera.
        _stats = GetComponent<UIDisplayStats>();
        
        _towerAnchorTransform = new GameObject("TowerAnchor").transform;
    }

    private void Start()
    {
        // Checking the required components:
        if (_guiBuildPanelPrefab == null) throw new Exception("Build panel prefab not installed!");
        if (_towerArcherPrefab == null) throw new Exception("Archer tower prefab not installed!");

        _buildPanel = Instantiate(_guiBuildPanelPrefab);
        _buildPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) StartCheck();
    }
    
    /// <summary>
    /// Click handler.
    /// </summary>
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
                CreateTower(_towerArcherPrefab, hit);
                break;
            case "BuildMagicTower":
                CreateTower(_towerMagicPrefab, hit);
                break;
            case "BuildSupportTower":
                CreateTower(_towerSupportPrefab, hit);
                break;
            case "BuildStoneTower":
                Debug.Log("BuildStoneTower");
                break;
            case "ArcherTower":
                Debug.Log("ArcherTower!");
                break;
            case "SupportTower":
                Debug.Log("SupportTower!");
                break;
            case "MagicTower":
                Debug.Log("MagicTower!");
                break;
            default:
                _buildPanel.SetActive(false);
                break;
        }
    }

    /// <summary>
    /// Creates a tower. 
    /// </summary>
    /// <param name="towerPrefab">Prefab to create a tower.</param>
    /// <param name="hit">Spawn point.</param>
    private void CreateTower(GameObject towerPrefab, RaycastHit hit)
    {
        if (!_stats.UpdateGoldCounter(100))
        {
            return;
        };
        var tower = Instantiate(towerPrefab, _towerAnchorTransform);
        var position = hit.transform.parent.transform.position;
        
        tower.transform.position = new Vector2(
            position.x, 
            position.y + 0.25f);
        
        _buildPanel.SetActive(false);
    }
}
    