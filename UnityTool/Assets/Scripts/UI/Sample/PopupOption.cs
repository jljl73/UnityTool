using Mignon.Scene;
using UnityEngine;
using UnityEngine.UI;

namespace Mignon.UI
{
    public class PopupOption : PopupBase
    {
        [SerializeField]
        private Button      buttonExit;

        public override ePopupType PopupType => ePopupType.Option;
        public override void Init()
        {
            base.Init();
            buttonExit.onClick.AddListener(OnClickHidePopup);
            
        }

        private void OnClickHidePopup()
        {
            SceneSystem.CurrentScene.PopupSystem.HidePopup();
        }
    }
}
