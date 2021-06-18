using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Inputer
    {
        public class NullInputer : IInputer
        {
            public bool IsItemButtonDown()
            {
                Debug.LogError("NullObject");
                return false;
            }

            public float HoriMoveDir()
            {
                Debug.LogError("NullObject");
                return 0.0f;
            }

            public float VertMoveDir()
            {
                Debug.LogError("NullObject");
                return 0.0f;
            }
        }
    }
}

