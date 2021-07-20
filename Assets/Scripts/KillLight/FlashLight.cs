using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtility;
using Zenra.Player;
namespace Zenra
{
    namespace KillLight
    {
        public class FlashLight : MonoBehaviour, ILightHit,ILightOnOff
        {
            static IPlayerKill _dummy = new NullObjectDead();
            IPlayerKill _playerKill = _dummy;

            public event LightHitdelegate LightHitEvent;
            public event LightExitdelegate LightExitEvent;

            PlayerCore playerCore;
            private void Start()
            {
                playerCore = Locator<PlayerCore>.GetT();
            }
            public void LightSwitch(bool isOn)
            {
                gameObject.SetActive(isOn);//これで電源つけたり切ったり
            }

            private void OnTriggerEnter2D(Collider2D collision)
            {
                _playerKill = collision.gameObject.GetComponent<IPlayerKill>();
                if (_playerKill != null)
                {
                    if (playerCore.IsHide) return;//隠れていたらセーフ
                    //_playerKill.PlayerKill();
                    LightHitEvent();
                }
            }
            private void OnTriggerExit2D(Collider2D collision)
            {
                var tempPlayerKill = collision.gameObject.GetComponent<IPlayerKill>();
                if (_playerKill != tempPlayerKill) return;
                LightExitEvent();
                //_playerKill = _dummy;
            }
        }
    }
}

