using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Player
    {
        public class NullClibableObject : IClimbable
        {
            public void CanClimb()
            {
                Debug.Log("NullObject");
            }

            public void CannotClimb()
            {
                Debug.Log("NullObject");
            }
        }
    }
}

