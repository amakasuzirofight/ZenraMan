using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Item;

namespace Zenra
{
    namespace Player
    {
        public class PlayerItemAbsorption : MonoBehaviour
        {
            static IItemAbsorption _dummy = new NullItemCore();
            IItemAbsorption _playerKill = _dummy;
            private PlayerCore _core;

            private void Start()
            {
                _core = MyUtility.Locator<PlayerCore>.GetT();
            }

            private void OnTriggerEnter2D(Collider2D collision)
            {
                _playerKill = collision.gameObject.GetComponent<IItemAbsorption>();
                var itemName = _playerKill?.GetItem();
                itemName = itemName ?? ItemName.NULL;
                _core.AddItem((ItemName)itemName);
            }
            private void OnTriggerExit2D(Collider2D collision)
            {
                var tempPlayerKill = collision.gameObject.GetComponent<IItemAbsorption>();
                if (_playerKill != tempPlayerKill) return;
                _playerKill = _dummy;
            }
        }
    }
}

