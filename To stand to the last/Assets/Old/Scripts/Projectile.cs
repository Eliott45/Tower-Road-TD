using UnityEngine;

namespace Old.Scripts
{
    public class Projectile : MonoBehaviour
    {
        /// <summary>
        /// The current target of the projectile. 
        /// </summary>
        private GameObject _target;
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
            if (other.gameObject == _target)
            {
                other.GetComponent<Old.Scripts.Enemy>().GetDamage(_damage);
                Destroy(gameObject);
            }
        }

        public void GetStats(GameObject target, float damage, float speed)
        {
            _target = target;
            _damage = damage;
            _speed = speed;
        }
    }
}

