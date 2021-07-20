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
            [SerializeField] CanvasGroup faceImageGroup = null;
            [SerializeField] FaceDetectorScene faceDetector = null;

            private PostEffector postEffect;
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
                faceDetector.trimMode = true;
                TrimFace();
            }

            private async void TrimFace()
            {
                faceImageGroup.DOFade(0, 1);
                animator.SetTrigger("TrimFaceMode");
                faceDetector.enabled = true;
                faceDetector.ResetFaceTex();
                
                await UniTask.WaitUntil(() => faceDetector.faceTexture != null);

                faceImageGroup.gameObject.SetActive(true);
                faceImageGroup.DOFade(1, 1);
                faceDetector.enabled = false;
                faceImage.texture = faceDetector.faceTexture;
                faceImage.SetNativeSize();
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