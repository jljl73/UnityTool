using Mignon.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mignon.Util;

namespace Mignon
{
    public class GameScene : MonoBehaviour
    {
        // юс╫ц
        static GameScene instance;
        public static GameScene Instance => instance;

        [SerializeField]
        private PopupSystem popupSystem;
        public PopupSystem PopupSystem => popupSystem;

        [SerializeField]
        private UIHomeView homeView;

        [SerializeField]
        private GameObject circle;
        private Stack<GameObject> list = new Stack<GameObject>();

        private void Start()
        {
            instance = this;
            Init();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                list.Push(circle.SpawnObject());
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (list.Count > 0)
                    list.Pop().DespawnObject();
            }
        }

        private void OnDestroy()
        {
            Dispose();
        }


        private void Init()
        {
            popupSystem.Init();
            homeView.Init();
        }
        
        private void Dispose()
        {
            popupSystem.Dispose();
            homeView.Dispose();
        }
    }
}
