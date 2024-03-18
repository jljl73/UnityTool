using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mignon.UI
{
    public class UIHomeView : UIView
    {
        [SerializeField]
        private Button buttonShowPopup;

        public override void Init()
        {
            base.Init();
            buttonShowPopup.onClick.AddListener(OnClickShowPopup);
        }

        private void OnClickShowPopup()
        {
            GameScene.Instance.PopupSystem.ShowPopup(new PopupData(ePopupType.Option, null));
        }
    }
}
