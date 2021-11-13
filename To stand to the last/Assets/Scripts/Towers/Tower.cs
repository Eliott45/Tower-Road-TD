using Mouse;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Tower : MonoBehaviour, IClicked
{
    [Header("Set tower options: ")] 
    [SerializeField] private protected float _damage;
    [SerializeField] private float _buildTime;
    [SerializeField] private int[] _prices;
    [SerializeField] private Sprite[] _towers;
    [SerializeField] private int _level;
    
    private BoxCollider2D _towerSpotCollider;

    private protected abstract void Building();
    private protected abstract void Upgrade();
    private protected abstract void Demolish();

    private void Start()
    {
        _towerSpotCollider = transform.parent.gameObject.GetComponent<BoxCollider2D>();
        _towerSpotCollider.enabled = false;
    }

    private void OnDestroy()
    {
        _towerSpotCollider.enabled = true;
    }

    public void OnClick()
    {
        throw new System.NotImplementedException();
    }
}