using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenra.KillLight;
using Zenject;
namespace Zenra
{
    namespace Police
    {
        public class EnemyObject : MonoBehaviour,IPoliceShot
        {
            [SerializeField] FlashLight lightOn;
            [Space(30)]
            [SerializeField] GameObject lightHitObj;
            ILightHit lightHit;
            [SerializeField, Range(0, 10)]
            float moveLenghTime;
            [ContextMenuItem("Reset", "ResetSpeed")]
            [SerializeField]
            float speed;
            float timecount;
            EnemyState enemyState = EnemyState.MOVE;
            Rigidbody2D rb;
            bool InShotLenge = false;//�˒����Ƀv���C���[�����邩�ǂ���
            Animator animator;

            public event PoliceShot_delegate PoliceShotEvent;

            void Start()
            {
                rb = GetComponent<Rigidbody2D>();
                animator = GetComponent<Animator>();
                lightHit = lightHitObj.GetComponent<ILightHit>();
                lightHit.LightHitEvent += LightHit_LightHitEvent;
                lightHit.LightExitEvent += LightHit_LightExitEvent;
            }

            private void LightHit_LightHitEvent()
            {
                enemyState = EnemyState.WEPONCHANGE;
                InShotLenge = true;
                StartCoroutine(ChangeGun());
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
            public void ActJudge(EnemyState enemystate)
            {
                switch (enemystate)
                {
                    case EnemyState.STAY:
                        break;
                    case EnemyState.WEPONCHANGE:
                        //�A�j���[�V����
                        if(InShotLenge)
                        {
                            animator.SetBool("ChangeGunFlg", true);
                        }
                        else
                        {
                            animator.SetBool("ChangeGunFlg", false);
                        }
                        break;
                    case EnemyState.SHOT:
                        animator.SetTrigger("GunShotTrigger");

                        break;
                    case EnemyState.MOVE:
                        animator.SetBool("ChangeGunFlg", false);
                        MoveBase();
                        break;

                    default:
                        break;
                }
            }

            bool canrun = true;
            bool isTurn = false;
            bool RandomLaunge = true;
            float rand;


            void MoveBase()
            {
               
                lightHitObj.SetActive(true);
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
                    rb.velocity = Vector2.zero;
                    //lightOn.LightSwitch(false);
                    animator.SetBool("TurnAnimFlg", true);
                    StartCoroutine("Turn");

                }
           
            }
            IEnumerator Turn()
            {
                
                yield return new WaitForSeconds(0.5f);
                if (enemyState == EnemyState.MOVE)
                {
                    transform.localScale *= new Vector2(-1, 1);
                    animator.SetBool("TurnAnimFlg", false);
                    speed *= -1;
                    canrun = true;
                    timecount = 0;
                    RandomLaunge = true;
                    lightOn.LightSwitch(true);
                }
            }
            IEnumerator ChangeGun()
            {
                yield return new WaitForSeconds(0.48f);
                if (InShotLenge == true)
                {
                    enemyState = EnemyState.SHOT;
                }
                else
                {
                    enemyState = EnemyState.MOVE;
                }
            }
            public void ShotGun()
            {
                animator.SetTrigger("GunShotTrigger");
            }
            public void ShotgunEnd()
            {
                //�C�x���g���s
                PoliceShotEvent(transform.position.x);
            }
            void ResetSpeed()
            {
                speed = 0;
            }

        }

    }
}
