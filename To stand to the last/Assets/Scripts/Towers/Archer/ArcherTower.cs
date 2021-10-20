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
        
    }
}
