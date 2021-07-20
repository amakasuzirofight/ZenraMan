using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Zenra.PostEffect;
using Zenra.SceneManagement;

namespace Zenra
{
    namespace StageSelect
    {
        public class StageElementView : MenuChild
        {
            [SerializeField] Image image = null;
            [SerializeField] Image selectedImage = null;
            
            private PostEffector postEffect;

            [Inject]
            private void Injection(PostEffector postEffect)
            {
                this.postEffect = postEffect;
            }

            public void Initalize(StageElementData data)
            {
                image.sprite = data.Sprite;
                gameObject.SetActive(true);
                SelectedAction.AddListener(() => selectedImage.gameObject.SetActive(true));
                DiselectedAction.AddListener(() => selectedImage.gameObject.SetActive(false));
                DecidedAction.AddListener(() => LoadStageScene(data.StageName));
            }

            public async void LoadStageScene(StageName name)
            {
                postEffect.Fade(PostEffectType.PressureFade, 1, Color.white, PostEffector.FadeType.Out);

                await UniTask.Delay(1150);

                await SceneLoader.LoadSceneAsync($"{name}", (op) => postEffect.Fade(PostEffectType.PressureFade, 1, Color.white, PostEffector.FadeType.In));
                //await SceneLoader.LoadSceneAsync("ShibataScene", (op) => postEffect.Fade(PostEffectType.PressureFade, 1, Color.white, PostEffector.FadeType.In));
            }
        }
    }
}