using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;

using Mignon.Data;
using Mignon.Scene;

namespace Mignon.UI
{
    public class UIHomeView : UIView
    {
        [SerializeField]
        private Button      buttonShowPopup;
        [SerializeField]
        private TMP_Text    textUserScore;
        [SerializeField]
        private TMP_Text    textUserNickName;

        public override void Init()
        {
            buttonShowPopup.onClick.AsObservable()
                .Subscribe(_ => OnClickShowPopup());
            
            DataCenter.Instance.UserData.Score.AsObservable()
                .Subscribe(gold => textUserScore.text = gold.ToString());
            
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
