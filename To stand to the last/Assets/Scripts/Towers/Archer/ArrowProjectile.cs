using Units;
using UnityEngine;

namespace Archer
{
    public class ArrowProjectile : MonoBehaviour
    {
        private GameObject _target; //The current target of the projectile. 
        private float _damage;
        private float _speed;
        
        private void FixedUpdate()
        {
            if (_target)
            { 
                transform.Translate(Vector2.up * ((_speed / 2) * Time.deltaTime));
            
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
            other.GetComponent<Unit>().GetDamage(_damage);
            Destroy(gameObject);
        }
        
        /// <summary>
        /// Set boom characteristics.
        /// </summary>
        /// <param name="target">Enemy.</param>
        /// <param name="speed">Speed of arrow.</param>
        /// <param name="damage">Damage to the enemy on hit.</param>
        public void SetStats(GameObject target, float speed, float damage)
        {
            _target = target;
            _damage = damage;
            _speed = speed;
        }
    }
}
