using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider))]
    internal class Coin : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case "ObjectDestroyer":
                    gameObject.SetActive(false);
                    break;
                case "Player":
                    break;
            }
        }
    }
}
