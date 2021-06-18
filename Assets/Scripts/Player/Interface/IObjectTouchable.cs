using UnityEngine;

namespace Zenra
{
    namespace Player
    {
        interface IObjectTouchable
        {
            void EnterAction(GameObject touchObj);
            void ExitAction(GameObject touchObj);
        }
    }
}
