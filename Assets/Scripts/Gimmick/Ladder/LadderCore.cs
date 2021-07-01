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
                private Vector2 _ladderPos;     // はしごの中心座標
                private BoxCollider2D boxCollider2D;

                private float _ladderHighestPosY;       // はしごのコライダーの最上点
                private float _ladderLowestPosY;        // はしごのコライダーの最下点

                private void Start()
                {
                    _ladderPos = gameObject.transform.position;
                    boxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();

                    // はしごのコライダーの最上点をの位置を計算。
                    // はしごの中心座標 + (コライダーの縦の長さ * オブジェクトの拡大率) / 2.0

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

