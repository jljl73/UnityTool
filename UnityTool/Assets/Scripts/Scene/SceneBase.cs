using Mignon.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mignon.Scene
{
    public enum eSceneType
    {
        SplashScene,
        GameScene,
    }

    public abstract class SceneBase : MonoBehaviour
    {
        [SerializeField]
        private     PopupSystem popupSystem;
        public      PopupSystem PopupSystem => popupSystem;

        [SerializeField]
        private     UIView      uiView;

        public abstract eSceneType  SceneType   { get; }
        private bool moveScene = false;

        private void Awake()
        {
            SceneSystem.CurrentScene = this;
            moveScene = SceneSystem.MoveFirstScene(SceneType);

            if (moveScene) return;

            Init();
            popupSystem?.Init();
            uiView?.Init();
        }


        private void OnDestroy()
        {
            if (moveScene) return;

            Dispose();
            popupSystem?.Dispose();
            uiView?.Dispose();
        }

        public abstract void Init();
        public abstract void Dispose();
    }
}
