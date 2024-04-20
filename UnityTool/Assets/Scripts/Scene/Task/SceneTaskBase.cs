using Mignon.UI;
using UnityEngine;

namespace Mignon.Scene
{
    public enum eSceneTaskType
    {
        Splash_Init     = 0,
        GameInit        = 101,
    }

    public abstract class SceneTaskBase : MonoBehaviour
    {
        [SerializeField]
        public UIView   CurrentView;

        public abstract eSceneTaskType SceneTaskType   { get; }

        public virtual void Init()
        {
            CurrentView?.Init();
        }

        public virtual void Dispose()
        {
            CurrentView?.Dispose();
        }

        public virtual void ActiveTask()
        {
            CurrentView?.Show();
        }

        public virtual void DeactiveTask()
        {
            CurrentView?.Hide();
        }
    }
}
