using System;
using UnityEngine;

namespace _Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 500f;
        
        private Rigidbody _rb;
        
        private float _xAxis;         
        private float _yAxis;            

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _xAxis = Input.GetAxis("Vertical");
            _yAxis = Input.GetAxis("Horizontal");
        }
        
        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _rb.AddForce(transform.forward * (_xAxis * (speed * Time.deltaTime)));
            _rb.AddForce(transform.right * (_yAxis * (speed * Time.deltaTime)));
            
        }
        
    }
}
