using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Inputer;

namespace Zenra
{
    namespace Player
    {
        public class PlayerMove : MonoBehaviour, IActionClimb
        {
            [SerializeField, Range(0, 50)]//0から50までの値をインスペクターでいじれるようになる
            private float _speed = 0;
            private IInputer _input = new NullInputer();//iinputerを作成　何も値入ってない
            private Rigidbody2D _rb2d = null;//ADDforce用RB
            private bool _canClimb = false;
            private Animator _animator = null;   // Animator用
            private SpriteRenderer _spriteRenderer;     // SpriteRenderer用

            private float addXSpeed;
            private float addYSpeed;

            public enum MoveMode
            {
                Xmove,
                ClimbLadder,
                DownLadder
            }

            MoveMode moveMode;


            private void Awake()
            {
                // たぶん自分のIActionClimbをBind
                MyUtility.Locator<IActionClimb>.Bind(this);
            }

            void Start()
            {
                _rb2d = GetComponent<Rigidbody2D>();
                _animator = GetComponent<Animator>();
                _spriteRenderer = GetComponent<SpriteRenderer>();
                _input = MyUtility.Locator<IInputer>.GetT();//ロケーターを使用して値が入ったIInputerを取得
                moveMode = MoveMode.Xmove;
            }

            void Update()
            {
                // 移動アニメーション管理
                if(addXSpeed != 0.0f)
                {
                    float reverse = Mathf.Sign(addXSpeed);      // 右移動なら1.0、左移動なら－1.0、0.0は出ない
                    bool filp = (reverse == -1) ? true : false;     // 左、つまり－1.0ならture
                    _spriteRenderer.flipX = filp;       // 左、つまり－1.0ならSpriteRendererのflipXする
                    _animator.SetBool("Walk", true);    // 移動アニメーション
                }
                else
                {
                    _animator.SetBool("Walk", false);       // X移動が0.0ならIdolアニメーション
                }

                if(_canClimb == true)
                {
                    _animator.SetBool("Climb", true);
                    if(addYSpeed == 0.0f)
                    {
                        _animator.SetBool("ClimbIdol", true);
                    }
                    else
                    {
                        _animator.SetBool("ClimbIdol", false);
                    }

                    
                }
                else
                {
                    _animator.SetBool("Climb", false);
                }
            }

            private void FixedUpdate()
            {
                if(_canClimb == false)
                {
                    addXSpeed = (_input.HoriMoveDir() * _speed);//実際に動かす
                    addYSpeed = 0.0f;
                }

                if (_canClimb == true)
                {
                    // Mathf.Sign()で中身が正の値なら1、負の値なら－1、0なら0を出す
                    if(moveMode == MoveMode.DownLadder && Mathf.Sign(_input.VertMoveDir()) == 1)
                    {
                        return;
                    }

                    if(moveMode == MoveMode.ClimbLadder && Mathf.Sign(_input.VertMoveDir()) == -1)
                    {
                        return;
                    }

                    addYSpeed = (_input.VertMoveDir() * _speed);
                    addXSpeed = 0.0f;
                }

                _rb2d.velocity = new Vector2(addXSpeed, addYSpeed);     // 移動時に重力が考慮されない
            }

            // はしごにプレイヤーの位置を補正する
            void IActionClimb.shiftPlayerPos(float x)
            {
                gameObject.transform.position = new Vector2(x, transform.position.y);
            }

            void IActionClimb.actionClimb(bool isClimb)
            {
                _canClimb = isClimb;
            }

            void IActionClimb.changeMoveMode(int enumNum)
            {
                moveMode = (MoveMode)enumNum;
                Debug.Log("MoveMode = " + moveMode);
            }
        }
    }
}

