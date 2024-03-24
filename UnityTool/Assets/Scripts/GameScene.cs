using Mignon.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mignon.Util;
using Mignon.Scene;

using UniRx;
using UniRx.Triggers;
using Mignon.Data;

namespace Mignon
{
    public class GameScene : SceneBase
    {
        public override eSceneType      SceneType       => eSceneType.GameScene;

        [SerializeField]
        private GameObject circle;
        private Stack<GameObject> list = new Stack<GameObject>();

        [SerializeField]
        private MapController mapController;


        public override void Init()
        {
            mapController.Init();

            TestInput();
        }

        public override void Dispose()
        {
            mapController.Dispose();
        }

        private void TestInput()
        {
            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.Alpha1))
                .Subscribe(_ =>
                {
                    list.Push(circle.SpawnObject());
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.Alpha2))
                .Subscribe(_ =>
                {
                    if (list.Count > 0)
                        list.Pop().DespawnObject();
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.Space))
                .Subscribe(_ =>
                {
                    DataCenter.Instance.UserData.Score.Value += 1;
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.Escape))
                .Subscribe(_ =>
                {
                    SceneSystem.ChangeScene(eSceneType.SplashScene);
                });
        }
    }
}
