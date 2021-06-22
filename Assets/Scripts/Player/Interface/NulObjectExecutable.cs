using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Player
    {
        public class NulObjectExecutable : IObjectExecutable
        {
            public void Execute()
            {
                Debug.Log("NullObject");
            }
        }
    }
}

