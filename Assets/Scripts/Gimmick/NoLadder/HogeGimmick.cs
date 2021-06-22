using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Gimmick
    {
        public class HogeGimmick : MonoBehaviour,IGimmickAction
        {
            public GimmickType[] GimmickTypes => new Gimmick.GimmickType[] { GimmickType.HIDE };

            public void GimmickAction()
            {
                Debug.Log("ƒMƒ~ƒbƒN”­“®‚³‚ê‚½");
            }
        }
    }
}

