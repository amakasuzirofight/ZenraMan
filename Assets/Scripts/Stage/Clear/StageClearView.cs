using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using Zenra.PostEffect;

namespace Zenra
{
    namespace Result
    {
        public class StageClearView : MonoBehaviour
        {
            private PostEffector postEffect;

            [Inject]
            private void Injection(PostEffector postEffect)
            {
                this.postEffect = postEffect;
            }

            public async void Show()
            {
                gameObject.SetActive(true);
                await UniTask.Delay(1500);
                postEffect.Fade(PostEffectType.ScrollSwipe, 0.5f, Color.black, PostEffector.FadeType.Out, DG.Tweening.Ease.Linear);
                await UniTask.Delay(500);
                new StageClear().Action((op) => postEffect.Fade(PostEffectType.ScrollSwipe, 0.5f, Color.black, PostEffector.FadeType.In, DG.Tweening.Ease.Linear));
            }
        }
    }
}