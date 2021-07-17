using Cysharp.Threading.Tasks;
using DG.Tweening;
using OpenCvSharp.Demo;
using UnityEngine;
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
            [SerializeField] Transform faceImage = null;
            [SerializeField] FaceDetectorScene faceDetector = null;

            [Inject] PostEffector postEffect;

            private IInputer input = null;

            
            private async void Awake()
            {
                input = MyUtility.Locator<IInputer>.GetT();
                postEffect.Fade(PostEffectType.PressureFade, 1, Color.white, PostEffector.FadeType.In);
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
                postEffect.Fade(PostEffectType.SimpleFade, 0.9f, Color.white, PostEffector.FadeType.Out);
                faceImage.DOScale(new Vector3(5, 5, 10), 1f).SetEase(Ease.InOutCubic).onComplete += () => 
                {
                    SceneLoader.LoadSceneAsync(Scenes.StageSelect, (op) =>
                    {
                        Debug.Log("OK");
                        postEffect.Fade(PostEffectType.SimpleFade, 1, Color.white, PostEffector.FadeType.In);
                    });
                };
                
            }
        }
    }
}