using UnityEngine;

namespace Archer
{
    /// <summary>
    /// Archers tower.
    /// </summary>
    public class ArcherTower : RangeTower
    {
        [Header("Set archer tower options:")] 
        [SerializeField] private GameObject _projectile;
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private ArcherUnit _archerUnit;

        private protected override void Update()
        {
            base.Update();
            if(_currentTarget != null) _archerUnit.Rotate(_currentTarget.transform.position.x);
        }

        private protected override void Attack()
        {
            base.Attack();
            _archerUnit.StartAttackAnimation();
            _archerUnit.Shoot(_projectile, _currentTarget, _projectileSpeed, _damage);
        }
        
    }
}
