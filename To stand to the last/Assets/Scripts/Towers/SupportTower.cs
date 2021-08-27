using Units;
using UnityEngine;

namespace Towers
{
    public class SupportTower : Tower
    {
        [Header("Set support tower options:")] 
        [SerializeField] private Defender[] _defenders;
        [SerializeField] private float _spawnTime;
            
        private protected override void Building() {}
        private protected override void Upgrade() {}
        private protected override void Demolish() {}

        private void Spawn() {}
    }
}
