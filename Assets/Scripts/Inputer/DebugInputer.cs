using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Inputer
    {
        public class DebugInputer : IInputer
        { 
            float IInputer.SideMoveDir()
            {
                return Input.GetAxisRaw("Horizontal");
            }

            bool IInputer.IsItemButtonDown()
            {
                return Input.GetKeyDown(KeyCode.Space);
            }
        }
    }
}

