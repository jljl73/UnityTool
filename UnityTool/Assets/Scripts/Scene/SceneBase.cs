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
        public abstract eSceneType  SceneType   { get; }

        private void Awake()
        {
            SceneSystem.CurrentScene = this;
            SceneSystem.MoveFirstScene(SceneType);

            popupSystem?.Init();

            Init();
        }


        private void OnDestroy()
        {
            popupSystem?.Dispose();

            Dispose();
        }

        public abstract void Init();
        public abstract void Dispose();
    }
}
