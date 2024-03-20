using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Mignon.Localization
{
    public class LocalizationText : MonoBehaviour
    {
        //[SerializeField]
        //private Text text;
        [SerializeField]
        private TMP_Text tmpText;
        [SerializeField]
        private string localKey;

        private void Awake()
        {
            LocalizationManager.OnChangedLanguage += SetLocalText;
        }

        private void OnDestroy()
        {
            LocalizationManager.OnChangedLanguage -= SetLocalText;
        }

        public void SetKey(string localkey)
        {
            this.localKey = localkey;
            SetLocalText();
        }

        public void SetLocalText()
        {
            //tmpText?.Local(localKey);
        }
    }

    public static class TextExtension
    {
        public static void Local(this TMP_Text tmpText, string key)
        {
            var localText = LocalizationManager.Local(key);
            tmpText.text = localText;
        }
    }
}
