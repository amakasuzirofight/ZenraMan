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
                    ladderPos = transform.position;     // はしごの座標を入れる
                }

                // はしごの座標だけ入れたかった（加藤）
            }
        }
    }
}

