
using Mignon.Data;

namespace Mignon.Scene
{
    public class SplashScene : SceneBase
    {

        public override eSceneType SceneType => eSceneType.SplashScene;

        public override void Init()
        {
            DataCenter.Instance.Init();
        }

        public override void Dispose()
        {
        }
    }
}
