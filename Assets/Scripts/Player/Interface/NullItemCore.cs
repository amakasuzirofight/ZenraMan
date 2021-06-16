using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Item;

namespace Zenra
{
    namespace Player
    {
        public class NullItemCore : IItemAbsorption
        {
            public ItemName GetItem()
            {
                Debug.Log("NullObject");
                return ItemName.NULL;
            }
        }
    }
}

