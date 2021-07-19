using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Player
    {
        public class PlayerHeadExplosion : MonoBehaviour
        {
            [SerializeField,Tooltip("吹き飛ぶ強さ")]
            float explosionPower = 10000.0f;

            private PlayerCore _playerCore = null;
            private Rigidbody2D rigidbody2D = null;
            private bool _playerDead;
            private bool once = false;

            void Awake() 
            {
                _playerCore = MyUtility.Locator<PlayerCore>.GetT();
                
            }

            void Start()
            {
                
            }

            void Update()
            {
                // これじゃダメなんだけどどうすることもできなかった…
                _playerDead = _playerCore.isDead;
                if(_playerDead == true || once == false)
                {
                    Debug.Log("HeadExplosion");
                    HeadExplosion();
                }
            }

            void HeadExplosion()
            {
                rigidbody2D = this.gameObject.AddComponent<Rigidbody2D>();
                rigidbody2D.AddForce(new Vector3(-10000.0f, 0.0f, 0.0f), ForceMode2D.Impulse);
            }
        }
    }
}

