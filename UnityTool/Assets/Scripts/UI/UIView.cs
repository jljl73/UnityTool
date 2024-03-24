using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mignon.UI
{
    public abstract class UIView : MonoBehaviour
    {
        public abstract void Init();

        public abstract void Dispose();

        public abstract void UpdateView();
    }
}
