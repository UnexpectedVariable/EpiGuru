using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal class ObjectMovementManager : MonoBehaviour, IPauseable
    {
        [SerializeField]
        private List<GameObject> _objects = new List<GameObject>();
        [SerializeField]
        private Vector3 _movement = Vector3.zero;

        private bool _isPaused = false;

        public void Move()
        {
            if (_isPaused) return;
            foreach (var obj in _objects)
            {
                obj.transform.position += _movement;
            }
        }

        public void Add(GameObject obj)
        {
            if (_objects.Contains(obj)) return;
            _objects.Add(obj);
        }

        public void TogglePause()
        {
            _isPaused = !_isPaused;
        }
    }
}
