using Mignon.Data;
using Mignon.Scene;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UniRx;
using Unity.VisualScripting;

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
