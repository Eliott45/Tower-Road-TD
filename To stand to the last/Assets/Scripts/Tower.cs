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
    
    private Animator _anim;
    
    [Header("Set Dynamically")]
    [SerializeField] private List<GameObject> targets;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (targets.Count > 0) {
            Shoot();
        } else
        {
            _anim.CrossFade("archer_1_idle", 0);
        }
    }

    private void Shoot()
    {
        _anim.CrossFade("archer_1_front_attack", 0);
        Debug.Log("Shoot the " + targets[0]);
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
