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
        [SerializeField]
        private GameManager gameManager;


        public override void Init()
        {
            gameManager.Initialize();

            TestInput();
        }

        public override void Dispose()
        {
            gameManager.Dispose();
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
