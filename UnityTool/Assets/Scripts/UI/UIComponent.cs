using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mignon.UI
{
    public class UIComponent : MonoBehaviour
    {
        public virtual void OnShow()
        {
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void OnHide() 
        {
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}