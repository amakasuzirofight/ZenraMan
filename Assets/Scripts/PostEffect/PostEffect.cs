using UnityEngine;
using DG.Tweening;

namespace Zenra
{
    namespace PostEffect
    {
        public class PostEffect
        {
            private IPlayPostEffect postEffectPlayer;
            private IGetMaterialData materialDB;

            public PostEffect(IPlayPostEffect postEffectPlayer, IGetMaterialData materialDB)
            {
                this.postEffectPlayer = postEffectPlayer;
                this.materialDB = materialDB;
            }

            public void SimpleFade(float time, Color color, FadeType fadeType)
            {
                Material mat = null;
                materialDB.SetShader(PostEffectType.SimpleFade, ref mat);
                mat.SetColor("_Color", color);
                int fadeId = Shader.PropertyToID("_Fade");
                switch (fadeType)
                {
                    case FadeType.In:
                        Debug.Log("IN");
                        postEffectPlayer.SetActive(true);
                        DOVirtual.Float(1, 0, time, value =>
                        {
                            mat.SetFloat(fadeId, value);
                        }).SetEase(Ease.Linear).onComplete += () => postEffectPlayer.SetActive(false);

                        break;
                    case FadeType.Out:
                        Debug.Log("OUT");
                        postEffectPlayer.SetActive(true);
                        DOVirtual.Float(0, 1, time, value =>
                        {
                            mat.SetFloat(fadeId, value);
                        }).SetEase(Ease.Linear);
                        break;
                }
            }

            public enum FadeType
            {
                In,
                Out,
            }
        }
    }
}