
using Mignon.UI;

namespace Mignon.Scene
{
    public class SplashScene : SceneBase
    {
        public override eSceneType SceneType => eSceneType.SplashScene;

        public override void Init()
        {
            SceneSystem.ChangeScene(eSceneType.GameScene);
        }

        public override void Dispose()
        {
        }
    }
}
