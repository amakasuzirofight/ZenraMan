using UnityEngine;
namespace Zenra
{
    namespace Player
    {
        interface IObjectExecutable
        {
            void Execute(Animator animator
                ,SpriteRenderer spriteRenderer
                ,Canvas canvas
                ,BoxCollider2D boxCollider2D);
        }
    }
}