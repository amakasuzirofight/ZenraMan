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
            public static Scenes NowScene { get; private set; } = Scenes.Title;

            public static AsyncOperation LoadSceneAsync(Scenes scene, Action<AsyncOperation> loadedAction = null)
            {
                AsyncOperation op = SceneManager.LoadSceneAsync(scene.ToString());

                Action<AsyncOperation> act = (op) => 
                {
                    loadedAction?.Invoke(op);
                    NowScene = scene;
                };

                op.completed += act;
                op.completed += (op) => { op.completed -= act; };

                return op;
            }
        }
    }
}