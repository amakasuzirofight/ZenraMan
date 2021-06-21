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

            void Start()
            {

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
            bool isrun;
            void MoveBase()
            {
                if (isrun)
                {
                    timecount += Time.deltaTime;
                }
                float rand = moveLenghTime + Random.Range(-0.5f, 0);
                //poliMove.Move(speed);//移動方法わからん
                StartCoroutine(PoliStop(enemyState, moveLenghTime));

            }
            public void MoveRial()
            {

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
