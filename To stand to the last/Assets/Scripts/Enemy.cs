using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set options")] 
    [SerializeField] private float health = 10f;
    [SerializeField] private float showDamageDuration = 0.1f;
    
    private Color[] _originalColors;
    private Material[] _materials;
    private float _damageDoneTime;
    private bool _showingDamage;
    
    private void Awake()
    {
        _materials = GetAllMaterials(gameObject);
        
        _originalColors = new Color[_materials.Length];
        for (var i = 0; i < _materials.Length; i++){
            _originalColors[i] = _materials[i].color;
        }
    }

    private void Update()
    {
        if (_showingDamage && Time.time > _damageDoneTime) {
            UnShowDamage();
        }
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        ShowDamage();
        if (health <= 0) Destroy(gameObject);
    }
    
    private void ShowDamage() {
        foreach (var m in _materials) {
            m.color = Color.red;
        }
        _showingDamage = true;
        _damageDoneTime = Time.time + showDamageDuration;
    }
    
    private void UnShowDamage() {
        for (var i = 0; i < _materials.Length; i++) {
            _materials[i].color = _originalColors[i];
        }
        _showingDamage = false;
    }
    
    /// <summary>
    /// Retrieving all materials of an object.
    /// </summary>
    /// <param name="go">Game object.</param>
    /// <returns>List of materials.</returns>
    private static Material[] GetAllMaterials(GameObject go) {
        var rends = go.GetComponentsInChildren<Renderer>();
        return(rends.Select(rend => rend.material).ToArray());
    }
    
}
