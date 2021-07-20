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
            private Animator _animator = null;
            private PlayerCore _core = null;

            void Awake()
            {
                _core = MyUtility.Locator<PlayerCore>.GetT();
            }

            void Start() 
            {
                _animator = GetComponent<Animator>();
            }

            public void PlayerKill()
            {
                _core.PlayerKill();
                _animator.SetTrigger("Dead");
            }
        }
    }
}

