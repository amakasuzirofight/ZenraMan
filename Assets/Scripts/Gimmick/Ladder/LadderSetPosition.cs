using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Gimmick
    {
        namespace Ladder
        {
            public class LadderSetPosition : MonoBehaviour
            {
                private Vector2 ladderPos;
                void Start()
                {
                    ladderPos = transform.position;     // �͂����̍��W������
                }

                // �͂����̍��W�������ꂽ�������i�����j
            }
        }
    }
}

