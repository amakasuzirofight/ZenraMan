using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Gimmick
    {
        namespace Ladder
        {
            public class LadderCore : MonoBehaviour, ISendLadderPos
            {
                private Vector2 _ladderPos;

                private void Start()
                {
                    _ladderPos = gameObject.transform.position;
                }

                public float SendLadderPosX()
                {
                    return _ladderPos.x;
                }

                public float SendLadderPosY()
                {
                    return _ladderPos.y;
                }
            }
        }
    }
}

