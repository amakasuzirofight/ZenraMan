using Zenra.SceneManagement;

namespace Zenra
{
    namespace Title
    {
        public class TitleCore
        {
            public void LoadStageSelectScene()
            {
                SceneLoader.LoadSceneAsync(Scenes.StageSelect);
            }
        }
    }
}