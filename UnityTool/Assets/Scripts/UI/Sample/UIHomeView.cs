using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;
using System;
using Mignon.Data;

namespace Mignon.UI
{
    public class UIHomeView : UIView
    {
        [SerializeField]
        private Button      buttonShowPopup;
        [SerializeField]
        private TMP_Text    textUserGold;
        [SerializeField]
        private TMP_Text    textUserNickName;

        List<IDisposable>   disposables = new List<IDisposable>();

        public override void Init()
        {
            buttonShowPopup.onClick.AsObservable()
                .Subscribe(_ => OnClickShowPopup());
            
            DataCenter.Instance.UserData.Gold.AsObservable()
                .Subscribe(gold => textUserGold.text = string.Format("Gold : {0}", gold));
            
            DataCenter.Instance.UserData.NickName.AsObservable()
                .Subscribe(nickname => textUserNickName.text = nickname);
        }

        public override void Dispose()
        {
        }

        public override void UpdateView()
        {
        }

        private void OnClickShowPopup()
        {
            SceneSystem.CurrentScene.PopupSystem.ShowPopup(new PopupData(ePopupType.Option, null));
        }

    }
}
