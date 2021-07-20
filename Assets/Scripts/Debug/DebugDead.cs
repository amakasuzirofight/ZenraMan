using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Player;


// これは最強のスクリプト。

namespace Zenra
{
    public class DebugDead : MonoBehaviour
    {
        [SerializeField,Tooltip("Player")]
        PlayerDead playerDead;

        [SerializeField,Tooltip("プレイヤーのアニメーション")]
        Animator animator;

        private int num = 0;
        private int num2 = 0;

        void Start()
        {
    
        }

        
        void Update()
        {
            // 死亡アニメーション
            if(Input.GetKeyDown(KeyCode.P))
            {
                playerDead.PlayerKill();
            }

            // しゃがみアニメーション
            if(Input.GetKeyDown(KeyCode.O))
            {
                num++;
                if(num %2 == 1)
                {
                    // 奇数
                    animator.SetTrigger("Squat");
                }
                else
                {
                    animator.SetTrigger("StandUp");
                }
                
            }

            if(Input.GetKeyDown(KeyCode.I))
            {
                num2++;
                if(num2 %2 == 1)
                {
                    // 奇数
                    animator.SetTrigger("Lift");
                }
                else
                {
                    animator.SetTrigger("TakeDown");
                }
            }

            if(Input.GetKeyDown(KeyCode.U))
            {
                
            }
        }
    }
}


