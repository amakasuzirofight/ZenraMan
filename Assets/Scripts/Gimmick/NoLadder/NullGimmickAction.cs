using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Gimmick
    {
        public class NullGimmickAction : IGimmickAction
        {
            public void HideAction()
            {
                Debug.LogError("NullObject");
            }
        }
    }
}

