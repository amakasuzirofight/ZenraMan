using UnityEngine;
using Zenject;
using DG.Tweening;

namespace Zenra
{
    namespace PostEffect
    {
        public class PostEffect
        {
            [Inject] private IPlayPostEffect postEffectPlayer;
            [Inject] private IGetMaterialData materialDB;

            public void SimpleFade(float time, Color color, FadeType fadeType)
            {
                Material mat = materialDB.GetMaterial(PostEffectType.SimpleFade);
                mat.SetColor("Color", color);

                int fadeId = "Fade".GetHashCode();
                switch(fadeType)
                {
                    case FadeType.In:
                        mat.DOFloat(0, fadeId, time).onComplete += postEffectPlayer.In;
                        break;
                    case FadeType.Out:
                        postEffectPlayer.Out();
                        mat.DOFloat(1, fadeId, time);
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