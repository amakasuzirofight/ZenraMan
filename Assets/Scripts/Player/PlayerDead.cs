using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.KillLight;

namespace Zenra
{
    namespace Player
    {
        public class PlayerDead : MonoBehaviour, IPlayerKill
        {
            PlayerCore _core = null;
            void Awake()
            {
                _core = MyUtility.Locator<PlayerCore>.GetT();
            }
            public void PlayerKill()
            {
                _core.PlayerKill();
            }
        }
    }
}

