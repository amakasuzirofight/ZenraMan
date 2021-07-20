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


            // アニメーション遷移がうまく行かない。なんかboolをtrueからfalseに
            // 切り替えるとちゃんと死んでくれる。謎。
            public void PlayerKill()
            {
                _core.PlayerKill();
                StartCoroutine("KillAnimation");
            }

            IEnumerator KillAnimation()
            {
                _animator.SetBool("Dead", true);
                yield return new WaitForSeconds(0.001f);
                _animator.SetBool("Dead", false);
            }
        }
    }
}

