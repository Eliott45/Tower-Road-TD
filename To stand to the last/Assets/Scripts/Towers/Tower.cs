using UnityEngine;

namespace Towers
{
    public abstract class Tower : MonoBehaviour
    {
        [Header("Set tower options: ")] 
        [SerializeField] private protected float _damage;
        [SerializeField] private ETypeDamage _typeDamage;
        [SerializeField] private float _buildTime;
        [SerializeField] private int[] _prices;
        [SerializeField] private Sprite[] _towers;
        [SerializeField] private int _level;
        
        private protected abstract void Building();
        private protected abstract void Upgrade();
        private protected abstract void Demolish();
    }
}
