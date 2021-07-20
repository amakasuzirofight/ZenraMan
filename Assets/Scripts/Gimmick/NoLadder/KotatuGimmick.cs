using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Gimmick
    {
        public class KotatuGimmick : MonoBehaviour,IGimmickAction
        {
            GimmickType[] IGimmickAction.GimmickTypes =>
                new GimmickType[3]
                {
                    GimmickType.HEAL,
                    GimmickType.HIDE,
                    GimmickType.SAVE
                };

            void IGimmickAction.GimmickAction()
            {
                Debug.Log("Kotatu");
            }
        }

    }
}
