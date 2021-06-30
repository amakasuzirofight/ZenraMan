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
                private Vector2 _ladderPos;     // �͂����̒��S���W
                private BoxCollider2D boxCollider2D;

                private float _ladderHighestPosY;       // �͂����̃R���C�_�[�̍ŏ�_
                private float _ladderLowestPosY;        // �͂����̃R���C�_�[�̍ŉ��_

                private void Start()
                {
                    _ladderPos = gameObject.transform.position;
                    boxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();

                    // �͂����̃R���C�_�[�̍ŏ�_���̈ʒu���v�Z�B
                    // �͂����̒��S���W + (�R���C�_�[�̏c�̒��� * �I�u�W�F�N�g�̊g�嗦) / 2.0

                    _ladderHighestPosY = _ladderPos.y + (boxCollider2D.size.y * transform.localScale.y) / 2.0f;
                    _ladderLowestPosY = _ladderPos.y - (boxCollider2D.size.y * transform.localScale.y) / 2.0f;                    
                }

                public float SendLadderPosX()
                {
                    return _ladderPos.x;
                }

                public float SendLadderPosY()
                {
                    return _ladderPos.y;
                }

                public float SendLadderHighestPosY()
                {
                    return _ladderHighestPosY;
                }

                public float SendLadderLowestPosY()
                {
                    return _ladderLowestPosY;
                }
            }
        }
    }
}

