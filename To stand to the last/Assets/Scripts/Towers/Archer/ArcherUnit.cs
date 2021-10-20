using System;
using UnityEngine;

namespace Archer
{
    public class ArcherUnit : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int Attack = Animator.StringToHash("Attack");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Shoot(GameObject projectile, GameObject target, float speed, float damage)
        {
            var go = Instantiate(projectile, transform);
            go.GetComponent<ArrowProjectile>().SetStats(target, speed, damage);
        }

        public void Rotate(float enemyPositionX)
        {
            if (enemyPositionX - transform.position.x <= 0)
            {
                if(transform.rotation.y == 0)
                {
                    transform.Rotate(0f, 180f, 0f, Space.World);
                }
            }
            else
            {
                if (transform.rotation.y != 0) transform.Rotate(0f, -180f, 0f);
            }
        }

        public void StartAttackAnimation()
        {
            _animator.SetBool(Attack, true);
        }
    }
}
