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
                //Å‰‚É‚Ç‚ê‚­‚ç‚¢ˆÚ“®‚·‚é‚©‚ğŒˆ‚ß‚ÄˆÚ“®‚·‚éBˆÚ“®‚Ì“r’†‚Åƒ‰ƒ“ƒ_ƒ€‚Å~‚Ü‚éB
                //‚¿‘Ö‚¦‚Ä‚¢‚éŠÔ‚É‰B‚ê‚Ä‹‚È‚¯‚ê‚ÎŒ‚‚Â
                //‚Æ‚è‚ ‚¦‚¸ˆÚ“®‚Æ”½“]‚¾‚¯s‚¤


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
                //poliMove.Move(speed);//ˆÚ“®•û–@‚í‚©‚ç‚ñ
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
