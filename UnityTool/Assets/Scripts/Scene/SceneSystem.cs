using UnityEngine.SceneManagement;

namespace Mignon.Scene
{
    public class SceneSystem 
    {
        static bool startFirstScene = false;
        public static SceneBase CurrentScene { get; private set; } = null;

        public static void SetScene(SceneBase scene)
        {
            CurrentScene = scene;
            CurrentScene.SceneInit();
        }

        public static bool MoveFirstScene(eSceneType sceneType)
        {
            if (startFirstScene)
                return false;

            startFirstScene = true;
            if (sceneType != eSceneType.SplashScene)
            {
                ChangeScene(eSceneType.SplashScene);
                return true;
            }

            return false;
        }

        public static void ChangeScene(eSceneType sceneType)
        {
            CurrentScene?.SceneDispose();
            var sceneName = sceneType.ToString();
            SceneManager.LoadScene(sceneName);
        }
    }
}
