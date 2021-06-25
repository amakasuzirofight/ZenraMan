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
            private RenderTexture renderTexture = null;

            public void In()
            {
                fadeBack.gameObject.SetActive(false);
            }

            public void Out()
            {
                fadeBack.gameObject.SetActive(true);
            }

            private void Awake()
            {
                renderTexture = new RenderTexture(Screen.width, Screen.height, 0, UnityEngine.Experimental.Rendering.GraphicsFormat.R8G8B8A8_UNorm);
                renderTexture.filterMode = FilterMode.Point;
                renderTexture.dimension = UnityEngine.Rendering.TextureDimension.Tex2D;
                GetComponent<Camera>().targetTexture = renderTexture;
            }
        }
    }
}