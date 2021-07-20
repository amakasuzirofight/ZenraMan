using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Player
    {
        public class NulObjectExecutable : IObjectExecutable
        {
            public void Execute(Animator animator,SpriteRenderer spriteRenderer,Canvas canvas,BoxCollider2D boxCollider2D)
            {
                Debug.Log("NullObject");
            }
        }
    }
}

