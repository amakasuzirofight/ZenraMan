using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zenra
{
    namespace PostEffect
    {
        public class PostEffectCamera : MonoBehaviour, IPlayPostEffect
        {
            [SerializeField] RawImage fadeBack = null;
            [SerializeField] RenderTexture renderTexture = null;

            private void Awake()
            {
                renderTexture.width = Screen.width;
                renderTexture.height = Screen.height;
            }

            void IPlayPostEffect.SetActive(bool b)
            {
                fadeBack.gameObject.SetActive(b);
            }
        }
    }
}