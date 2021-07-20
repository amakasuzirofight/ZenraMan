using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenra.KillLight;
using Zenject;
using UnityEngine.Experimental.Rendering.Universal;
namespace Zenra
{
    namespace Police
    {
        public class EnemyObject : MonoBehaviour,IPoliceShot
        {
            [SerializeField] GameObject lightHitObj;
            ILightHit lightHit;
            ILightOnOff lightOnOff;
            const float LIGHTPOWER = 0.5f;
            [SerializeField] Light2D light2d;
            [SerializeField, Range(0, 10)]
            float moveLenghTime;
            [ContextMenuItem("Reset", "ResetSpeed")]
            [SerializeField]
            float speed;
            [SerializeField] GameObject ShotEffect;
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
                lightOnOff = lightHitObj.GetComponent<ILightOnOff>();
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
                        //lightOnOff.LightSwitch(true);
                        light2d.intensity=LIGHTPOWER;
                        break;
                    case EnemyState.WEPONCHANGE:
                        //�A�j���[�V����
                        if (InShotLenge)
                        {
                            animator.SetBool("ChangeGunFlg", true);
                        }
                        //else
                        //{
                        //    animator.SetBool("ChangeGunFlg", false);

                        //}
                        light2d.intensity = 0;

                        break;
                    case EnemyState.SHOT:
                        animator.SetTrigger("GunShotTrigger");
                        light2d.intensity = 0;

                        break;
                    case EnemyState.MOVE:
                        light2d.intensity = LIGHTPOWER;
                        MoveBase();
                        break;
                    //case EnemyState.TURN:
                    //    lightOnOff.LightSwitch(true);
                    //    break;
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
                    animator.SetBool("ChangeGunFlg", false);
                }
            }
            public void  EndChangeWeponMortion()//�A�j���[�V�����C�x���g
            {
                animator.SetTrigger("NormalRunTrigger");
                enemyState = EnemyState.MOVE;
            }
            public void ShotGun()//�A�j���[�V�����C�x���g
            {
                enemyState = EnemyState.SHOT;
            }
            public void ShotgunEnd()//�A�j���[�V�����C�x���g
            {
                Debug.Log(PoliceShotEvent);
                //�C�x���g���s
                PoliceShotEvent(transform.position.x);
            }
            public void SHotEff()//�A�j���[�V�����C�x���g
            {
                var eff = Instantiate(ShotEffect);
                eff.transform.position = new Vector3(transform.position.x, transform.position.y + 10, 0);
            }
            void ResetSpeed()
            {
                speed = 0;
            }

        }

    }
}
