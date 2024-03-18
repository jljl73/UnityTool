using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mignon.UI
{
    public abstract class UIView : MonoBehaviour
    {
        public virtual void Init()
        {
        }

        public virtual void Dispose()
        {
        }

        public virtual void UpdateView()
        {
        }
    }
}
