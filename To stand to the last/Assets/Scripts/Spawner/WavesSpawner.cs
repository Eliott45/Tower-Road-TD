using System.Collections.Generic;
using UnityEngine;

namespace Spawner
{
    public class WavesSpawner : MonoBehaviour
    {
        [Header("Set wave options:")]
        [SerializeField] private Transform _origin;
        [SerializeField] private Transform _destination;
        [SerializeField] private Wave[] _waves;

        private void SpawnWave() { }
    }
}
