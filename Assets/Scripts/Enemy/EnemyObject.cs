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
                //Å‰‚É‚Ç‚ê‚­‚ç‚¢ˆÚ“®‚·‚é‚©‚ğŒˆ‚ß‚ÄˆÚ“®‚·‚éBˆÚ“®‚Ì“r’†‚Åƒ‰ƒ“ƒ_ƒ€‚Å~‚Ü‚éB
                //‚¿‘Ö‚¦‚Ä‚¢‚éŠÔ‚É‰B‚ê‚Ä‹‚È‚¯‚ê‚ÎŒ‚‚Â
                //‚Æ‚è‚ ‚¦‚¸ˆÚ“®‚Æ”½“]‚¾‚¯s‚¤


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
                //Å‰‚ÉˆÚ“®ŠÔ‚ğŒˆ‚ß‚é
                if (RandomLaunge == true)
                {
                    rand = moveLenghTime + Random.Range(-0.1f, 0);
                    RandomLaunge = false;
                }
                if (canrun)
                {
                    //ˆÚ“®’†‚ÉŠÔ‚ğ}‚é
                    timecount += Time.deltaTime;
                    //ˆÚ“®‚·‚é
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    Debug.Log("ˆÚ“®’†");
                    if (rand < timecount)
                    {
                        canrun = false;
                        Debug.Log("”½“]");
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
