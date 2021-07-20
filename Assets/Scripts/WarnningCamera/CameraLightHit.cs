using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra.WarnningCamera
{
    public class CameraLightHit : MonoBehaviour/*, IWhenWarnningLevelUp*/,IIsWarnningCamera

    {
        //public event PlayerDiscover PlayerDiscoverEvent;
        bool hitFlg;

        public void IsDiscoverZenra()
        {
            
        }

        // Start is called before the first frame update
        void Start()
        {
            hitFlg = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    IWhenPlayerHitCamera whenPlayerHitCamera = default;
        //    whenPlayerHitCamera.GoEventHitCamera(this);

        //    if (collision.gameObject.name == "Player")
        //    {
        //        if (hitFlg) return;
        //        PlayerDiscoverEvent();
        //        hitFlg = true;
        //    }
        //}
    }

}
