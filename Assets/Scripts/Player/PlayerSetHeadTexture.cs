using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zenra
{
    namespace Player
    {
        public class PlayerSetHeadTexture : MonoBehaviour
        {
            [SerializeField, Tooltip("顔に貼るテクスチャ")]
            RawImage rawImage;

            // private const float setTextureYPos = 10.0f;     // 顔面テクスチャをいい感じの場所に移動させる

            void Start()
            {
                // テクスチャを入れる
                //rawImage.texture = 
                // rawImage.transform.position = new Vector3(0.0f, setTextureYPos, 0.0f);
            }

            void Update()
            {
                
            }
        }
    }
}

