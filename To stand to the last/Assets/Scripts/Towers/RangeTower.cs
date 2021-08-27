using UnityEngine;

namespace Towers
{
    public class RangeTower : Tower
    {
        [Header("Set range tower options:")] 
        [SerializeField] private float _rangeAttack;
        [SerializeField] private float _speedAttack;

        private protected override void Building() {}
        private protected override void Upgrade() {}
        private protected override void Demolish() {}

        private protected virtual void Attack() {}
    }
}
