using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;
using Mignon.Data;
using UnityEngine.UI;
using Mignon.Scene;

namespace Mignon.UI
{
    public class UISplashView : UIView
    {
        [SerializeField]
        private TMP_InputField iptNickname;
        [SerializeField]
        private Button buttonStart;

        public override void Init()
        {
            iptNickname.onValueChanged.AsObservable().Subscribe(text => DataCenter.Instance.UserData.NickName.Value = text);
            buttonStart.onClick.AsObservable().Subscribe(_ => { SceneSystem.ChangeScene(eSceneType.GameScene); });
        }

        public override void Dispose()
        {
        }


        public override void UpdateView()
        {
        }
    }
}
