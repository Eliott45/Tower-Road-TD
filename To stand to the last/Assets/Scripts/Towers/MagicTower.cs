using UnityEngine;

namespace Towers
{
    public class MagicTower : RangeTower
    {
        [Header("Set magic tower options: ")] 
        [SerializeField] private GameObject _attackEffect;
    }
}
