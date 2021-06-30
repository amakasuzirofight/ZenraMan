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

            private float addXSpeed;
            private float addYSpeed;


            private void Awake()
            {
                // たぶん自分のIActionClimbをBind
                MyUtility.Locator<IActionClimb>.Bind(this);
            }

            void Start()
            {
                _rb2d = GetComponent<Rigidbody2D>();
                _input = MyUtility.Locator<IInputer>.GetT();//ロケーターを使用して値が入ったIInputerを取得
            }

            void Update()
            {

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
                    addYSpeed = (_input.VertMoveDir() * _speed);
                    addXSpeed = 0.0f;
                }

                _rb2d.velocity = new Vector2(addXSpeed, addYSpeed);     // 移動時に重力が考慮されない
                //Debug.Log("addYSpeed" + addYSpeed);
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

            void IActionClimb.CheckLadderUpDown(float ladderPosY)
            {
                if (transform.position.y < ladderPosY)
                {
                    //Debug.Log("Up");
                }
                else
                {
                    //Debug.Log("Down");
                }
            }
        }
    }
}

