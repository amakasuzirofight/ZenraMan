using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Police;

namespace Zenra
{
    namespace Player
    {
        public class PlayerHeadExplosion : MonoBehaviour
        {
            [SerializeField,Tooltip("吹き飛ぶ強さ")]
            float explosionPower = 10000.0f;

            [SerializeField,Tooltip("警官射撃event")]
            GameObject enemy;

            [SerializeField, Tooltip("プレイヤーAnimator")]
            Animator playerAnimator;
            
            private IPoliceShot _IPoliceShot;

            private PlayerCore _playerCore = null;
            private Rigidbody2D rigidbody2D = null;
            private bool _playerDead;
            private bool once = false;
            private float dir = -1.0f;

            void Awake() 
            {
                _playerCore = MyUtility.Locator<PlayerCore>.GetT();
                _IPoliceShot = enemy.GetComponent<IPoliceShot>();
                _IPoliceShot.PoliceShotEvent += EnemyShot;
            }

            void Start()
            {
                
            }

            void Update()
            {
                // これじゃダメなんだけどどうすることもできなかった…
                _playerDead = _playerCore.isDead;
                if(_playerDead == true && once == false)
                {
                    // Deadステートにいるのか調べる
                    if(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Dead") == true)
                    {
                        // Deadステートのアニメーションを正規化した物のある一定に位置していたら頭が吹っ飛ぶ。
                        // 正直Event生やしたい
                        if(playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.4f)
                        {
                            Debug.Log("HeadExplosion");
                            HeadExplosion();
                        }
                    }
                }
            }

            void FixedUpdate() 
            {
                
            }

            void HeadExplosion()
            {
                rigidbody2D = this.gameObject.AddComponent<Rigidbody2D>();
                rigidbody2D.AddForce(new Vector3(dir * 10000.0f, 0.0f, 0.0f), ForceMode2D.Impulse);
                once = true;
            }

            void EnemyShot(float enemyPos)
            {
                Debug.Log("EnemyShot");
                float d = enemyPos - this.transform.position.x;
                if(d < 0.0f)
                {
                    // (プレイヤー) - (エネミー)がマイナスなら頭を右に吹き飛ぶためにdirを「＋」にする。
                    dir = 1.0f;
                }
                else
                {
                    // (プレイヤー) - (エネミー)がプラスなら頭を左に吹き飛ぶためにdirを「ー」にする。
                    dir = -1.0f;
                }
            }
        }
    }
}

