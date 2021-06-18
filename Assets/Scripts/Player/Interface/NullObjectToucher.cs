using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Player
    {
        public class NullObjectToucher : IObjectTouchable
        {
            public void EnterAction(GameObject touchObj)
            {
                Debug.LogError("NullObject");
            }

            public void ExitAction(GameObject touchObj)
            {
                Debug.LogError("NullObject");
            }
        }
    }
}

