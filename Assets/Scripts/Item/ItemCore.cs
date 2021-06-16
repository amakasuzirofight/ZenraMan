using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Player;

namespace Zenra
{
    namespace Item
    {
        public class ItemCore : MonoBehaviour, IItemAbsorption
        {
            [SerializeField]
            private ItemInfo _info;
            private SpriteRenderer _renderer;

            private void Start()
            {
                _renderer = gameObject.GetComponent<SpriteRenderer>();
                _renderer.sprite = _info.sprite;
            }

            ItemName IItemAbsorption.GetItem()
            {
                ChangeRendererActive();
                return _info.itemName;
            }

            private void ChangeRendererActive()
            {
                gameObject.SetActive(false);
            }
        }
    }
}

