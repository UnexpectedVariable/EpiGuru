using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.MainScene
{
    internal class Director : MonoBehaviour
    {
        [SerializeField]
        private Button _startButton = null;

        private void Start()
        {
            _startButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("GameloopScene");
            });
        }
    }
}
