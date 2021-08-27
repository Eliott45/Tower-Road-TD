using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class StoneTower : RangeTower
    {
        [Header("Set stone tower options:")] 
        [SerializeField] private GameObject _projectile;
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private float _projectileRegion;
    }
}