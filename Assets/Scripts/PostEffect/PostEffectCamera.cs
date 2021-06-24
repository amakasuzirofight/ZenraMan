using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace PostEffect
    {
        public class PostEffectCamera : MonoBehaviour
        {
            private RenderTexture renderTexture = null;

            [SerializeField] private Material[] mats = null;

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