using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ranged towers. 
/// </summary>
public class RangeTower : Tower
{
    [Header("Set range tower options:")]
    [SerializeField] private float _rangeAttack;
    [SerializeField] private float _speedAttack;
    [SerializeField] private ETypeDamage _typeDamage;
    
    [Header("Set range tower dynamically:")]
    [SerializeField] private List<GameObject> _targets = new List<GameObject>();
    [SerializeField] protected GameObject _currentTarget;
    
    private float _reloadingTime; // Time when tower can attack again

    private protected virtual void Awake()
    {
        GetComponent<CircleCollider2D>().radius = _rangeAttack; // Set collider range for attack.
    }

    private protected virtual void Update()
    {
        if (_targets.Count > 0 && _reloadingTime < Time.time)
        {
            if(FilterTargets()) Attack();
        }
    }

    private void OnTriggerEnter2D(Collider2D unitCollider)
    {
        if (!unitCollider.CompareTag("Enemy")) return;
        _targets.Add(unitCollider.gameObject);
    }
        
    private void OnTriggerExit2D(Collider2D unitCollider)
    {
        if (unitCollider.gameObject == _currentTarget) _currentTarget = null;
        _targets.Remove(unitCollider.gameObject);
    }
    
    private protected override void Building() {}
    private protected override void Upgrade() {}
    private protected override void Demolish() {}

    private protected virtual void Attack()
    {
        if (!_currentTarget)
        {
            _currentTarget = _targets[0];
        }
        _reloadingTime = Time.time + _speedAttack;
    }

    /// <summary>
    /// Delete null targets.
    /// </summary>
    /// <returns>Targets are available.</returns>
    private bool FilterTargets()
    {
        _targets.RemoveAll(x => !x);
        return _targets.Count > 0;
    } 
    
}