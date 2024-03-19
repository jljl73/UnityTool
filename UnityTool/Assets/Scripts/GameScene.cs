using Mignon.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mignon.Util;
using Mignon.Scene;

namespace Mignon
{
    public class GameScene : SceneBase
    {
        public override eSceneType      SceneType       => eSceneType.GameScene;

        [SerializeField]
        private UIHomeView homeView;

        [SerializeField]
        private GameObject circle;
        private Stack<GameObject> list = new Stack<GameObject>();

        public override void Init()
        {
            homeView.Init();
        }

        public override void Dispose()
        {
            homeView.Dispose();
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
    }
}
