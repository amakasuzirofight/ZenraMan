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

            void Start()
            {
                // テクスチャを入れる
                rawImage.texture = MyUtility.Locator<Texture2D>.GetT();
            }

            void Update()
            {
                
            }
        }
    }
}

