using System;
using Units;
using UnityEngine;

namespace Archer
{
    public class ArrowProjectile : MonoBehaviour
    {
        private GameObject _target; //The current target of the projectile. 
        private float _damage;
        private float _speed;
        private ETypeDamage _typeDamage;

        private void Update()
        {
            if (Camera.main is null || !_target) return;
            // Look at enemy
            var direction = Camera.main.ScreenToWorldPoint(_target.transform.position) - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _speed * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (_target)
            { 
                transform.Translate(Vector2.up * (_speed * 0.5f * Time.deltaTime));
            
                transform.position = Vector3.MoveTowards(
                    transform.position, 
                    _target.transform.position, 
                    Time.deltaTime * _speed);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject != _target) return;
            other.GetComponent<Unit>().GetDamage(_damage, _typeDamage);
            Destroy(gameObject);
        }

        /// <summary>
        /// Set boom characteristics.
        /// </summary>
        /// <param name="target">Enemy.</param>
        /// <param name="speed">Speed of arrow.</param>
        /// <param name="damage">Damage to the enemy on hit.</param>
        /// <param name="typeDamage">Type of damage.</param>
        public void SetStats(GameObject target, float speed, float damage, ETypeDamage typeDamage = ETypeDamage.Physical)
        {
            _target = target;
            _damage = damage;
            _speed = speed;
            _typeDamage = typeDamage;
        }
        

    }
}
