using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class CoinSpawner : MonoBehaviour, ISpawner
    {
        [SerializeField]
        private GameObject _coin = null;
        [SerializeField]
        private GameObject _pool = null;

        private System.Random _rng = null;

        public float MinimalX = 0;
        public float MaximumX = 0;

        public System.Random RNG
        {
            set => _rng = value;
        }

        [ContextMenu("Spawn")]
        public GameObject Spawn()
        {
            if (_rng == null) return null;
            return SpawnCoin().gameObject;
        }

        private GameObject SpawnCoin()
        {
            var x = MaximumX * (_rng.NextDouble() * 2 - 1);

            Vector3 position = transform.position;
            position.x = (float)x;
            position.y = _coin.transform.lossyScale.x;

            GameObject coin = Instantiate(_coin, _pool.transform);
            coin.transform.position = position;

            return coin;
        }
    }
}
