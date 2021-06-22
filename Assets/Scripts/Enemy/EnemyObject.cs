using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Zenra
{
    namespace Police
    {
        public class EnemyObject : MonoBehaviour
        {
            [SerializeField]
            PoliMove poliMove;
            [SerializeField, Range(0, 10)]
            float moveLenghTime;
            [SerializeField]
            float speed;
            float timecount;
            EnemyState enemyState;

            Rigidbody2D rb;
            void Start()
            {
                rb = GetComponent<Rigidbody2D>();
            }

            void Update()
            {
                //最初にどれくらい移動するかを決めて移動する。移動の途中でランダムで止まる。
                //持ち替えている間に隠れて居なければ撃つ
                //とりあえず移動と反転だけ行う


            }
            private void FixedUpdate()
            {
                MoveBase();
            }
            bool canrun = true;
            bool RandomLaunge = true;
            float rand;
            void MoveBase()
            {
                //最初に移動時間を決める
                if (RandomLaunge == true)
                {
                    rand = moveLenghTime + Random.Range(-0.1f, 0);
                    RandomLaunge = false;
                }
                if (canrun)
                {
                    //移動中に時間を図る
                    timecount += Time.deltaTime;
                    //移動する
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    Debug.Log("移動中");
                    if (rand < timecount)
                    {
                        canrun = false;
                        Debug.Log("反転");
                        StartCoroutine("Turn");
                       
                    }
                }
                else
                {
                    rb.velocity = Vector2.zero;
                }

            }
            IEnumerator Turn()
            {
                yield return new WaitForSeconds(0.5f);
                transform.localScale *= new Vector2(-1, 1);
                speed *= -1;
                canrun = true;
                timecount = 0;
                RandomLaunge = true;
            }

            public void ChangeState(EnemyState enemystate)
            {
                switch (enemystate)
                {
                    case EnemyState.STAY:
                        break;
                    case EnemyState.WEPONCHANGE:
                        break;
                    case EnemyState.SHOT:
                        break;
                    case EnemyState.MOVE:
                        break;
                    default:
                        break;
                }
            }
            IEnumerator MoveStop(EnemyState enemyState, float waitTime)
            {
                yield return new WaitForSeconds(waitTime);

            }
            IEnumerator PoliStop(EnemyState enemyState, float waitTime)
            {
                yield return new WaitForSeconds(waitTime);
            }

        }

    }
}
