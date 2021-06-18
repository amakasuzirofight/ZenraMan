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
            IItemAbsorption _playerKill = _dummy;
            private PlayerCore _core;

            private void Start()
            {
                _core = MyUtility.Locator<PlayerCore>.GetT();
            }

            public void EnterAction(IItemAbsorption obj)
            {
                _playerKill = obj;
                var itemName = _playerKill?.GetItem();
                if (itemName == null) return;
                _core.AddItem((ItemName)itemName);
            }
            public void ExitAction(IItemAbsorption obj)
            { 
                if (_playerKill != obj) return;
                _playerKill = _dummy;
            }
        }
    }
}

