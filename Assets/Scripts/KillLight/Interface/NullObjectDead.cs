using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace KillLight
    {
        public class NullObjectDead : IPlayerKill
        {
            bool IsShowMasege = true;
            public void PlayerKill()
            {
                if (!IsShowMasege) return;
                Debug.LogWarning("NullObjct");
            }
        }
    }
}

