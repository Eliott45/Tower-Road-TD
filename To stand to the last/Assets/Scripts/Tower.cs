using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Set tower options:")]
    [SerializeField] private float _damage;
    /// <summary>
    /// Time until the next shot.
    /// </summary>
    [SerializeField] private float _reloadDuration;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _projectileSpeed;
    
    [Header("Set Dynamically")]
    [SerializeField] private List<GameObject> _targets;
    
    private Animator _animator;
    private Quaternion _transformRotation;
    private float _timeAtkDone;
    private static readonly int Attack = Animator.StringToHash("Attack");


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _transformRotation = transform.rotation;
    }

    private void Update()
    {
        if (_targets.Count > 0 && _timeAtkDone < Time.time)
        {
            Shoot();
        }
        else
        {
            _animator.SetBool(Attack, false);
        }
    }

    private void Shoot()
    {
        _animator.SetBool(Attack, true);

        if (_targets[0].transform.position.x - transform.position.x <= 0) {
            _transformRotation.y = 180f;
        } else
        {
            _transformRotation.y = 0f;
        }
        
        transform.rotation = _transformRotation;
        
        var go = Instantiate(_projectilePrefab);
        go.transform.position = transform.position;
        go.GetComponent<Projectile>().GetStats(_targets[0], _damage, _projectileSpeed);
        
        _timeAtkDone = Time.time + _reloadDuration;
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
}
