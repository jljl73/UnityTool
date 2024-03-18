using Mignon.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


        private void Start()
        {
            instance = this;
            Init();
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
