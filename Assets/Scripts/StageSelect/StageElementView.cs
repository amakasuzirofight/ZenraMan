using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace StageSelect
    {
        public class StageElementView : MonoBehaviour, IStageElementInitalize
        {
            [SerializeField] SpriteRenderer spriteRenderer = null;

            void IStageElementInitalize.Initalize(StageElementData data)
            {
                spriteRenderer.sprite = data.Sprite;
                gameObject.SetActive(true);
            }

            public void LoadStageScene()
            {

            }
        }
    }
}