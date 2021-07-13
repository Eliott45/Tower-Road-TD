using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Set tower options:")]
    [SerializeField] private float damage;
    /// <summary>
    /// Time until the next shot.
    /// </summary>
    [SerializeField] private float reloadDuration;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed;
    
    [Header("Set Dynamically")]
    [SerializeField] private List<GameObject> targets;
    
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
        if (targets.Count > 0 && _timeAtkDone < Time.time)
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

        if (targets[0].transform.position.x - transform.position.x <= 0) {
            _transformRotation.y = 180f;
        } else
        {
            _transformRotation.y = 0f;
        }
        
        transform.rotation = _transformRotation;
        
        var go = Instantiate(projectilePrefab);
        go.transform.position = transform.position;
        go.GetComponent<Projectile>().GetStats(targets[0], damage, projectileSpeed);
        
        _timeAtkDone = Time.time + reloadDuration;
    }
    


    private void OnTriggerEnter2D(Collider2D unitCollider)
    {
        if (!unitCollider.CompareTag("Enemy")) return;
        targets.Add(unitCollider.gameObject);
    }
    
    private void OnTriggerExit2D(Collider2D unitCollider)
    {
        targets.Remove(unitCollider.gameObject);
    }
}
