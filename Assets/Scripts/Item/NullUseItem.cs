using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Item
    {
        public class NullUseItem : IUseItem
        {
            public void ItemAct(UseItemDS date)
            {
                Debug.LogError("NullObject");
            }
        }
    }
}

