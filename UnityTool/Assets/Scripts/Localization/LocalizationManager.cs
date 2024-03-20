using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mignon.Localization
{
    public class LocalizationManager
    {
        public static SystemLanguage CurrentLanguage
        {
            get
            {
                var langId = PlayerPrefs.GetInt("Lang", (int)SystemLanguage.English);
                return (SystemLanguage)langId;
            }
            set
            {
                var langId = (int)value;
                PlayerPrefs.SetInt("Lang", langId);
            }
        }

        public static Action OnChangedLanguage;

        public static void ChangeLanguage(SystemLanguage language)
        {
            CurrentLanguage = language;
            OnChangedLanguage?.Invoke();    
        }

        public static string Local(string key)
        {
            string localText = string.Empty;
            switch(CurrentLanguage)
            {
                // TODO: ¾ð¾îº° string Setting
            }
            return localText;
        }
    }
}
