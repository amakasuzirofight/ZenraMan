using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Item;

namespace Zenra
{
    namespace Player
    {
        public class PlayerItemAbsorption: IObjectTouchable
        {
            static IItemAbsorption _dummy = new NullItemCore();
            IItemAbsorption _itemCore = _dummy;
            private PlayerCore _core;

            public PlayerItemAbsorption()
            {
                _core = MyUtility.Locator<PlayerCore>.GetT();
            }

            public void EnterAction(GameObject touchObj)
            {
                _itemCore = touchObj.GetComponent<IItemAbsorption>();
                var itemName = _itemCore?.GetItem();
                if (itemName == null) return;
                _core.AddItem((ItemName)itemName);
            }

            public void ExitAction(GameObject touchObj)
            {
                if (_itemCore != touchObj.GetComponent<IItemAbsorption>()) return;
                _itemCore = _dummy;
            }
        }
    }
}

