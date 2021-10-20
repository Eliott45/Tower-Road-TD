using System.Collections.Generic;
using Towers;
using UnityEngine;

public class RangeTower : Tower
{
    [Header("Set range tower options:")]
    [SerializeField] private float _rangeAttack;
    [SerializeField] private float _speedAttack;
    
    [Header("Set range tower dynamically:")]
    [SerializeField] private List<GameObject> _targets = new List<GameObject>();
    
    private void Awake()
    {
        GetComponent<CircleCollider2D>().radius = _rangeAttack;
    }

    private void OnTriggerEnter2D(Collider2D unitCollider)
    {
        if (!unitCollider.CompareTag("Enemy")) return;
        _targets.Add(unitCollider.gameObject);
    }
        
    private void OnTriggerExit2D(Collider2D unitCollider)
    {
        _targets.Remove(unitCollider.gameObject);
    }
    
    private protected override void Building() {}
    private protected override void Upgrade() {}
    private protected override void Demolish() {}

    private protected virtual void Attack() {}
}