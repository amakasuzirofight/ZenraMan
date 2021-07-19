using Cysharp.Threading.Tasks;
using DG.Tweening;
using MyUtility;
using OpenCvSharp.Demo;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Zenra.Inputer;
using Zenra.PostEffect;
using Zenra.SceneManagement;

namespace Zenra
{
    namespace Title
    {
        public class TitleView : MonoBehaviour
        {
            [SerializeField] Animator animator = null;
            [SerializeField] RawImage faceImage = null;
            [SerializeField] FaceDetectorScene faceDetector = null;

            PostEffector postEffect;

            private IInputer input = null;

            [Inject]
            private void Injection(PostEffector postEffect)
            {
                this.postEffect = postEffect;
            }
            
            private async void Awake()
            {
                input = MyUtility.Locator<IInputer>.GetT();
                postEffect.Fade(PostEffectType.PressureFade, 0.5f, Color.white, PostEffector.FadeType.In);
                await UniTask.WaitUntil(() => input.IsItemButtonDown());
                TrimFace();
            }

            private async void TrimFace()
            {
                animator.SetTrigger("TrimFaceMode");
                faceDetector.enabled = true;
                faceDetector.ResetFaceTex();
                await UniTask.WaitUntil(() => faceDetector.faceTexture != null);
                faceDetector.enabled = false;
                animator.SetTrigger("TrimFaceIsOK");

                while (true)
                {
                    if(input.IsItemButtonDown())
                    {
                        DecideTrimFace();
                        return;
                    }
                    else
                    if (input.IsGimmickActivateButtonDown())
                    {
                        TrimFace();
                        return;
                    }
                    await UniTask.DelayFrame(1);
                }
            }

            private void DecideTrimFace()
            {
                Locator<Texture2D>.Bind(faceDetector.faceTexture);
                postEffect.Fade(PostEffectType.SimpleFade, 0.9f, Color.white, PostEffector.FadeType.Out);
                faceImage.transform.DOScale(new Vector3(5, 5, 10), 1f).SetEase(Ease.OutQuad).onComplete += () => 
                {
                    SceneLoader.LoadSceneAsync(Scenes.StageSelect, (op) =>
                    {
                        postEffect.Fade(PostEffectType.SimpleFade, 1, Color.white, PostEffector.FadeType.In);
                    });
                };
                
            }
        }
    }
}