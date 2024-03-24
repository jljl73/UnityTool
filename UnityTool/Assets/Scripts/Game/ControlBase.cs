using UnityEngine;

namespace Mignon.Game
{
    public abstract class ControlBase : MonoBehaviour
    {
        public abstract void Init();
        public abstract void Dispose();
    }
}
