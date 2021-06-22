using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Player
    {
        public class NullItemUsable : IItemUsable
        {
            public void FinishUseItem()
            {
                Debug.LogError("NullObject");
            }

            public bool GetIsUseItem()
            {
                Debug.LogError("NullObject");
                return false;
            }
        }
    }
}

