using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Assets.Scripts
{
    internal class Director : MonoBehaviour
    {
        [SerializeField]
        private ObstacleSpawner _obstacleSpawner = null;
        [SerializeField]
        private CoinSpawner _coinSpawner = null;
        [SerializeField]
        private ObjectMovementManager _movementManager = null;

        [SerializeField]
        private GameObject _plane = null;
        [SerializeField] 
        private GameObject _obstacle = null;

        [SerializeField]
        private int _seed = 0;
        [SerializeField]
        private bool _useSeed = false;
        [SerializeField]
        private System.Random _rng = null;

        [SerializeField]
        private float _spawnInterval = 0f;
        [SerializeField]
        private float _moveInterval = 0f;
        [SerializeField]
        private bool _isWorking = false;

        private void Start()
        {
            if (_useSeed) _rng = new System.Random(_seed);
            else _rng = new System.Random();

            InitializeObstacleSpawner();
            InitializeCoinSpawner();
        }

        private void InitializeCoinSpawner()
        {
            _coinSpawner.RNG = _rng;
            _coinSpawner.MinimalX = _plane.transform.lossyScale.x * -5;
            _coinSpawner.MaximumX = _plane.transform.lossyScale.x * 5;
        }

        private void InitializeObstacleSpawner()
        {
            _obstacleSpawner.RNG = _rng;
            _obstacleSpawner.PositionCount = (int)(_plane.transform.lossyScale.x * 10 / _obstacle.transform.lossyScale.x);
        }

        private void Spawn(ISpawner spawner)
        {
            var gObject = spawner?.Spawn();
            _movementManager?.Add(gObject);
        }

        [ContextMenu("Move")]
        public void Move()
        {
            _movementManager?.Move();
        }

        private async void SpawnLoopAsync(ISpawner spawner)
        {
            while(_isWorking && spawner != null)
            {
                Spawn(spawner);
                await Task.Delay(TimeSpan.FromSeconds(_spawnInterval));
            }
        }

        private async void MoveLoopAsync()
        {
            while(_isWorking && _movementManager != null)
            {
                Move();
                await Task.Delay(TimeSpan.FromSeconds(_moveInterval));
            }
        }

        [ContextMenu("Begin")]
        public async void Begin()
        {
            _isWorking = true;
            SpawnLoopAsync(_obstacleSpawner);
            MoveLoopAsync();
            await Task.Delay(TimeSpan.FromSeconds(_spawnInterval * 0.5));
            SpawnLoopAsync(_coinSpawner);
        }
    }
}
