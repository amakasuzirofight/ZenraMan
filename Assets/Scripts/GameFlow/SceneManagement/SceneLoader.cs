using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Zenra
{
    namespace SceneManagement
    {
        public static class SceneLoader
        {
            private static Scenes nowScene = Scenes.Title;

            private static AsyncOperation LoadSceneAsync(Scenes scene, Action<AsyncOperation> loadedAction = null)
            {
                AsyncOperation op = SceneManager.LoadSceneAsync(scene.ToString());
                op.completed += loadedAction;
                return op;
            }
        }
    }
}