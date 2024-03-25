using Mignon.Data;
using Mignon.Scene;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Mignon.UI
{
    public class PopupGameOver : PopupBase
    {
        [SerializeField]
        private Button buttonExit;
        [SerializeField]
        private TMP_Text textScore;


        public override ePopupType PopupType => ePopupType.GameOver;

        public override void Init()
        {
            base.Init();
            //buttonExit.onClick.AddListener(OnClickHidePopup);
            buttonExit.onClick.AsObservable().Subscribe(_ => OnClickHidePopup());
        }

        public override void OnShow(PopupData popupData)
        {
            base.OnShow(popupData);

            textScore.text = DataCenter.Instance.UserData.Score.ToString();
        }

        private void OnClickHidePopup()
        {
            SceneSystem.CurrentScene.PopupSystem.HidePopup();
            SceneSystem.ChangeScene(eSceneType.GameScene);
        }
    }
}
