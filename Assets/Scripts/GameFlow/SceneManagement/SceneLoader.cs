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
            public static AsyncOperation LoadSceneAsync(Scenes scene, Action<AsyncOperation> loadedAction = null)
            {
                string sceneName = scene.ToString();
                return LoadSceneAsync(sceneName, loadedAction);
            }

            public static AsyncOperation LoadSceneAsync(string sceneName, Action<AsyncOperation> loadedAction = null)
            {
                AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);

                Action<AsyncOperation> act = loadedAction;

                op.completed += act;
                op.completed += (op) => { op.completed -= act; };

                return op;
            }
        }
    }
}