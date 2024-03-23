using Cysharp.Threading.Tasks;
using Mignon.Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mignon
{
    public class SceneSystem 
    {
        static bool startFirstScene = false;
        public static SceneBase CurrentScene;

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
            var sceneName = sceneType.ToString();
            SceneManager.LoadScene(sceneName);
        }
    }
}
