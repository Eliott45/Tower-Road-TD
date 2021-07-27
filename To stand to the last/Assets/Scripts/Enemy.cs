using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [Header("Set options")] 
    [SerializeField] private float _health = 10f;
    [SerializeField] private float _showDamageDuration = 0.1f;
    
    private Color[] _originalColors;
    private Material[] _materials;
    private float _damageDoneTime;
    private bool _showingDamage;
    private Animator _animator;
    
    private static readonly int Alive = Animator.StringToHash("alive");

    private void Awake()
    {
        _materials = GetAllMaterials(gameObject);
        
        _originalColors = new Color[_materials.Length];
        for (var i = 0; i < _materials.Length; i++){
            _originalColors[i] = _materials[i].color;
        }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_showingDamage && Time.time > _damageDoneTime) {
            UnShowDamage();
        }
    }
    
    public void GetDamage(float damage)
    {
        _health -= damage;
        ShowDamage();
        if (_health <= 0)
        {
            Fell();
        };
    }
    
    /// <summary>
    /// Make unit red to show damage. 
    /// </summary>
    private void ShowDamage() {
        foreach (var m in _materials) {
            m.color = Color.red;
        }
        _showingDamage = true;
        _damageDoneTime = Time.time + _showDamageDuration;
    }
    
    private void UnShowDamage() {
        for (var i = 0; i < _materials.Length; i++) {
            _materials[i].color = _originalColors[i];
        }
        _showingDamage = false;
    }

    /// <summary>
    /// Start to fall.
    /// </summary>
    private void Fell()
    {
        GetComponent<NavMeshAgent2D>().speed = 0;
        _animator.SetBool(Alive, false);
    }

    public void Die()
    {
        Destroy(gameObject);
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
