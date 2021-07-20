using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace WarnningCamera
    {
        public class MoveWarnning : MonoBehaviour
        {
            bool isElectric;//�d�̓t���O�@�@�����Ă�Ɠ����@�@�@�g�����킩��񂯂ǈꉞ


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
                if (!isElectric) return;//�d�͂��Ȃ��Ɠ����Ȃ�

                if (transform.rotation.eulerAngles.z >= maxRotate || transform.rotation.eulerAngles.z <= minRotate)//����ɒB�����甽�]������
                {
                    if (isCoroutine == false)//���̏������̎���x��������Ăق���
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
                if (isturn == false)//���]���͓�����Ƃ���
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
