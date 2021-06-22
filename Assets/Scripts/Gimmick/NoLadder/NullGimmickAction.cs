using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Gimmick
    {
        public class NullGimmickAction : IGimmickAction
        {
            public GimmickType[] GimmickTypes
            {
                get
                {
                    Debug.Log("NulObject");
                    return new GimmickType[] { GimmickType.NULL };
                }
            }

            public void GimmickAction()
            {
                Debug.LogError("NullObject");
            }
        }
    }
}

