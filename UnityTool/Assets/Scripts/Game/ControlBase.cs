using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mignon
{
    public abstract class ControlBase : MonoBehaviour
    {
        public abstract void Init();
        public abstract void Dispose();
    }
}