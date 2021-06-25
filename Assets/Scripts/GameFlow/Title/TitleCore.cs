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
//ゲームを起動するとタイトルシーンへ移動
//タイトル画面でボタンを押すとステージセレクトシーンへ移動
//ステージを選択して入ることができる
//ステージのシーンへ移動
//