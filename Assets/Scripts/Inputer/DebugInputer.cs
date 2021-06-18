using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Inputer
    {
        public class DebugInputer : IInputer
        { 
            float IInputer.HoriMoveDir()
            {
                return Input.GetAxisRaw("Horizontal");
            }

            float IInputer.VertMoveDir()
            {
                return Input.GetAxisRaw("Vertical");
            }

            bool IInputer.IsItemButtonDown()
            {
                return Input.GetKeyDown(KeyCode.Space);
            }
        }
    }
}

