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
                //�ŏ��ɂǂꂭ�炢�ړ����邩�����߂Ĉړ�����B�ړ��̓r���Ń����_���Ŏ~�܂�B
                //�����ւ��Ă���ԂɉB��ċ��Ȃ���Ό���
                //�Ƃ肠�����ړ��Ɣ��]�����s��


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
                //poliMove.Move(speed);//�ړ����@�킩���
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
