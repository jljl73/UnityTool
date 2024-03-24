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
            moveScene = SceneSystem.MoveFirstScene(SceneType);

            if (moveScene == false)
                SceneSystem.SetScene(this);
        }

        public void SceneInit()
        {
            Init();
            popupSystem?.Init();
            uiView?.Init();
        }


        public void SceneDispose()
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
