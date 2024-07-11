using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class Wall : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _pieces = null;

        public void Disable(int[] indexes)
        {
            foreach(var index  in indexes)
            {
                _pieces[index].SetActive(false);
            }
        }

        public void Enable()
        {
            foreach(var piece in _pieces)
            {
                piece.SetActive(true);
            }
        }
    }
}
