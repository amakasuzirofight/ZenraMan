using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace WarnningCamera
    {
        public class MoveWarnning : MonoBehaviour
        {
            bool isElectric;//電力フラグ　　建ってると動く　　　使うかわからんけど一応


            [SerializeField] float moveSpeed;
            [SerializeField] float maxRotate;
            [SerializeField] float minRotate;

            float rotatePoint;
            bool isturn;
            bool isCoroutine;
            // Start is called before the first frame update
            void Start()
            {
                isturn = false;
                isCoroutine = false;
                isElectric = true;
                rotatePoint = transform.rotation.z;
            }
            // Update is called once per frame
            void Update()
            {
                Move();
                if (Input.GetKeyDown(KeyCode.Return))//test
                {
                    isElectric = false;
                }
            }

            public void Move()
            {
                if (!isElectric) return;//電力がないと動かない

                if (transform.rotation.eulerAngles.z >= maxRotate || transform.rotation.eulerAngles.z <= minRotate)//上限に達したら反転させる
                {
                    if (isCoroutine == false)//この条件下の時一度だけやってほしい
                    {
                        isCoroutine = true;
                        isturn = true;
                        StartCoroutine(Turn());
                    }
                }
                else
                {
                    isCoroutine = false;

                }
                if (isturn == false)//反転中は動かんといて
                {
                    rotatePoint += moveSpeed;
                }
                transform.rotation = Quaternion.Euler(0, 0, rotatePoint);

            }
            IEnumerator Turn()
            {

                yield return new WaitForSeconds(0.5f);
                moveSpeed *= -1;
                isturn = false;

            }

        }

    }
}
