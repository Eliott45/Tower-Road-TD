using UnityEngine;

namespace Towers
{
    public class ArcherTower : RangeTower
    {
        [Header("Set archer tower options:")] 
        [SerializeField] private GameObject _projectile;
        [SerializeField] private float _projectileSpeed;
    }
}
