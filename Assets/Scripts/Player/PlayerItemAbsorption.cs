using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Item;

namespace Zenra
{
    namespace Player
    {
        public class PlayerItemAbsorption
        {
            static IItemAbsorption _dummy = new NullItemCore();
            IItemAbsorption _itemCore = _dummy;
            private PlayerCore _core;

            public PlayerItemAbsorption()
            {
                Debug.Log("あああ");
                _core = MyUtility.Locator<PlayerCore>.GetT();
            }

            public void EnterAction(IItemAbsorption obj)
            {
                _itemCore = obj;
                var itemName = _itemCore?.GetItem();
                if (itemName == null) return;
                _core.AddItem((ItemName)itemName);
            }
            public void ExitAction(IItemAbsorption obj)
            { 
                if (_itemCore != obj) return;
                _itemCore = _dummy;
            }
        }
    }
}

