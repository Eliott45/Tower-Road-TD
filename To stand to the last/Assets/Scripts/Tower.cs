using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Set tower options:")]
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed;
    
    private Animator _animator;
    private Quaternion _transformRotation;
    
    [Header("Set Dynamically")]
    [SerializeField] private List<GameObject> targets;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _transformRotation = transform.rotation;
    }

    private void Update()
    {
        if (targets.Count > 0) Shoot();
    }

    private void Shoot()
    {
        _animator.CrossFade("archer_1_front_attack", 0);
        if (targets[0].transform.position.x - transform.position.x <= 0) {
            _transformRotation.y = 180f;
        } else
        {
            _transformRotation.y = 0f;
        }
        transform.rotation = _transformRotation;
        // var go = Instantiate(projectilePrefab);
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
