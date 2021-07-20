using UnityEngine;
namespace Zenra
{
    namespace Player
    {
        interface IObjectExecutable
        {
            void Execute(Animator animator,SpriteRenderer spriteRenderer,Canvas canvas);
        }
    }
}