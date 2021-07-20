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

            [SerializeField, Tooltip("プレイヤーAnimator")]
            Animator playerAnimator;

            [SerializeField, Tooltip("プレイヤーの頭のキャンバス")]
            GameObject playerHead;

            private PlayerCore _playerCore = null;
            private Rigidbody2D rigidbody2D = null;
            private bool dead = false;
            private bool once = false;
            private float dir = -1.0f;

            void Awake() 
            {
                _playerCore = MyUtility.Locator<PlayerCore>.GetT();
            }

            void Start()
            {
                
            }

            void Update()
            {
                if(dead == true && once == false)
                {
                    // Deadステートにいるのか調べる
                    if(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Dead") == true)
                    {
                        // Deadステートのアニメーションを正規化した物のある一定に位置していたら頭が吹っ飛ぶ。
                        // 正直Event生やしたい
                        if(playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.4f)
                        {
                            HeadExplosion();
                        }
                    }
                }
            }

            void HeadExplosion()
            {
                rigidbody2D = playerHead.AddComponent<Rigidbody2D>();
                rigidbody2D.AddForce(new Vector3(dir * explosionPower, 0.0f, 0.0f), ForceMode2D.Impulse);
                Debug.Log("HeadExplosion");
                once = true;
            }

            private void OnTriggerEnter2D(Collider2D other) 
            {
                if(other.GetComponent<IShotable>() != null)
                {
                    _playerCore.PlayerKill();
                    playerAnimator.SetTrigger("Dead");
                    Debug.Log("Hit");
                    float d = other.transform.position.x - this.transform.transform.position.x;
                    if(d < 0.0f)
                    {
                        dir = 1.0f;
                    }
                    else
                    {
                        dir = -1.0f;
                    }

                    
                    dead = true;


                }
            }
        }
    }
}

