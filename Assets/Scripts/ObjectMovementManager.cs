using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class ObjectMovementManager : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _objects = new List<GameObject>();
        [SerializeField]
        private Vector3 _movement = Vector3.zero;

        public void Move()
        {
            foreach (var obj in _objects)
            {
                obj.transform.position += _movement;
            }
        }

        public void Add(GameObject obj)
        {
            _objects.Add(obj);
        }
    }
}
