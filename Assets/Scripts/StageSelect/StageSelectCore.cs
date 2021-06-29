using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.SceneManagement;

namespace Zenra
{
    namespace StageSelect
    {
        public class StageSelectCore
        {
            public void LoadStageScene(StageName name)
            {
                SceneLoader.LoadSceneAsync($"{Scenes.Stage}_{name}");
            }
        }
    }
}