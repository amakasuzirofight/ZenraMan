using System;
using UnityEngine;
using Zenject;
using Zenra.PostEffect;
using Zenra.SceneManagement;

namespace Zenra
{
    namespace Result
    {
        public class StageClear
        {
            public void Action(Action<AsyncOperation> endLoadAction)
            {
                Debug.Log("CLEAR");
                SceneLoader.LoadSceneAsync(Scenes.StageSelect, endLoadAction);
            }
        }
    }
}