
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.WarnningCamera;
using MyUtility;
namespace Zenra.Player
{
    public class PlayerHitWCamera : MonoBehaviour, IWhenWarnningLevelUp
    {
        public event PlayerDiscover PlayerDiscoverEvent;
        PlayerCore playerCore;
        // Start is called before the first frame update
        void Start()
        {
            playerCore = Locator<PlayerCore>.GetT();
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<IIsWarnningCamera>() != null)//ÉJÉÅÉâÇæÇ¡ÇΩÇÁ
            {
                if (playerCore.IsHide) return;
                PlayerDiscoverEvent();
            }
        }
    }

}
