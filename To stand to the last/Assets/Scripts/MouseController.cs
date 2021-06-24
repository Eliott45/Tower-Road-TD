using System;
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
    
    private static Transform _towerAnchorTransform;

    private void Awake()
    {
        _camera = Camera.main; // Get main camera.
        
        _towerAnchorTransform = new GameObject("TowerAnchor").transform;
    }

    private void Start()
    {
        // Checking the required components:
        if (guiBuildPanelPrefab == null) throw new Exception("Build panel prefab not installed!");
        if (towerArcherPrefab == null) throw new Exception("Archer tower prefab not installed!");

        _buildPanel = Instantiate(guiBuildPanelPrefab);
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
                var tower = Instantiate(towerArcherPrefab,_towerAnchorTransform);
                var position = hit.transform.parent.transform.position;
                tower.transform.position = new Vector2(position.x + 0.08f, position.y + 0.2f);

                _buildPanel.SetActive(false);
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
            case "ArcherTower":
                Debug.Log("ArcherTower!");
                break;
            default:
                _buildPanel.SetActive(false);
                break;
        }
    }
}
    