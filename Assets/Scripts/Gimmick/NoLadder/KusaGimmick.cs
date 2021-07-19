using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Zenra
{
    namespace Gimmick
    {
        public class KusaGimmick : MonoBehaviour, IGimmickAction
        {
            GimmickType[] IGimmickAction.GimmickTypes => new GimmickType[1] { GimmickType.HIDE };

            void IGimmickAction.GimmickAction()
            {
                Debug.Log("ëêÉMÉ~ÉbÉN");
            }
        }
    }
}

