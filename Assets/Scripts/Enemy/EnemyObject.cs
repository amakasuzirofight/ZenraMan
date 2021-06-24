using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenra.KillLight;
namespace Zenra
{
    namespace Police
    {
        public class EnemyObject : MonoBehaviour
        {
            [SerializeField]
            ILightHit lightHit;
            [SerializeField, Range(0, 10)]
            float moveLenghTime;
            [ContextMenuItem("Reset", "ResetSpeed")]
            [SerializeField]
            float speed;
            float timecount;
            EnemyState enemyState=EnemyState.MOVE;
            Rigidbody2D rb;
            bool InShotLenge=false;//�˒����Ƀv���C���[�����邩�ǂ���
            void Start()
            {
                rb = GetComponent<Rigidbody2D>();
                lightHit = GetComponent<ILightHit>();
                lightHit.LightHitEvent += LightHit_LightHitEvent;
                lightHit.LightExitEvent += LightHit_LightExitEvent;
            }

            private void LightHit_LightHitEvent()
            {
                enemyState = EnemyState.WEPONCHANGE;
                InShotLenge = true;
            }

            private void LightHit_LightExitEvent()
            {
                InShotLenge = false;
            }

            void Update()
            {
                //�ŏ��ɂǂꂭ�炢�ړ����邩�����߂Ĉړ�����B�ړ��̓r���Ń����_���Ŏ~�܂�B
                //�����ւ��Ă���ԂɉB��ċ��Ȃ���Ό���
                //�Ƃ肠�����ړ��Ɣ��]�����s��


            }
            private void FixedUpdate()
            {
                ActJudge(enemyState);
                
            }
            bool canrun = true;
            bool turnflg = false;
            bool RandomLaunge = true;
            float rand;
            void MoveBase()
            {
                //�ŏ��Ɉړ����Ԃ����߂�
                if (RandomLaunge == true)
                {
                   
                    rand = moveLenghTime + Random.Range(-0.1f, 0);
                    RandomLaunge = false;
                }
                if (canrun)
                {
                    //�ړ����Ɏ��Ԃ�}��
                    timecount += Time.deltaTime;
                    //�ړ�����
                    rb.velocity = new Vector2(speed, rb.velocity.y);

                }
                else
                {
                    rb.velocity = Vector2.zero;
                }
                if (rand < timecount)
                {
                    timecount = 0;
                    canrun = false;
                    StartCoroutine("Turn");

                }

            }
            IEnumerator Turn()
            {
                yield return new WaitForSeconds(0.5f);
                if (enemyState == EnemyState.MOVE)
                {
                    transform.localScale *= new Vector2(-1, 1);
                    speed *= -1;
                    canrun = true;
                    timecount = 0;
                    RandomLaunge = true;
                }
            }
            public void LightHitCheck()
            {

            }
            public void ActJudge(EnemyState enemystate)
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
                        MoveBase();
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
            void ResetSpeed()
            {
                speed = 0;
            }

        }

    }
}
