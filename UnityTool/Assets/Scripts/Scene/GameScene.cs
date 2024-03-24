using Mignon.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mignon.Util;
using Mignon.Scene;

using UniRx;
using UniRx.Triggers;

using Mignon.Data;
using Mignon.Game;


namespace Mignon
{
    public class GameScene : SceneBase
    {
        public override eSceneType      SceneType       => eSceneType.GameScene;

        [Header("Controller")]
        [SerializeField]
        private MapController mapController;
        [SerializeField]
        private BlockController blockController;


        public override void Init()
        {
            mapController.Init();
            blockController.Init();

            TestInput();
        }

        public override void Dispose()
        {
            mapController.Dispose();
            blockController.Dispose();
        }

        private void TestInput()
        {
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
