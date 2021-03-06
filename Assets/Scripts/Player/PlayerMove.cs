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
            [SerializeField]//0から50までの値をインスペクターでいじれるようになる
            private float _speed = 0;

            private IInputer _input = new NullInputer();//iinputerを作成　何も値入ってない
            private Rigidbody2D _rb2d = null;//ADDforce用RB
            private bool _canClimb = false;
            private Animator _animator = null;   // Animator用
            private SpriteRenderer _spriteRenderer;     // SpriteRenderer用
            private IPlayerMoveStateGet _IPlayerMoveStateGet;

            private float addXSpeed;
            private float addYSpeed;
            private float moveLock = 1.0f;  // プレイヤーの移動固定用、1.0なら移動可能、0.0なら不可

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
                _IPlayerMoveStateGet = MyUtility.Locator<PlayerCore>.GetT();
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
                // 移動可能か調べる
                if(_IPlayerMoveStateGet.IsMove() == false)
                {
                    moveLock = 0.0f;
                }
                else
                {
                    moveLock = 1.0f;
                }

                // 移動アニメーション管理
                if(addXSpeed != 0.0f && moveLock != 0.0f)
                {
                    float reverse = Mathf.Sign(addXSpeed);      // 右移動なら1.0、左移動なら－1.0、0.0は出ない
                    this.gameObject.transform.localScale = new Vector3(reverse, 1.0f, 1.0f);        // 描画反転処理
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

                _rb2d.velocity = new Vector2(addXSpeed, addYSpeed) * moveLock;     // 移動時に重力が考慮されない
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

            public GameObject GetObj()
            {
                return this.gameObject;
            }
        }
    }
}

