using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace KillLight
    {
        public class FlashLight : MonoBehaviour
        {
            static IPlayerKill _dummy = new NullObjectDead();
            IPlayerKill _playerKill = _dummy;
            
            private void OnTriggerEnter2D(Collider2D collision)
            {
                _playerKill = collision.gameObject.GetComponent<IPlayerKill>();
                _playerKill?.PlayerKill();
            }
            private void OnTriggerExit2D(Collider2D collision)
            {
                var tempPlayerKill = collision.gameObject.GetComponent<IPlayerKill>();
                if (_playerKill != tempPlayerKill) return;
                _playerKill = _dummy;
            }
        }
    }
}

