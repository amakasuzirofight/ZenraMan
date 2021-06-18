using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Inputer;

namespace Zenra
{
    namespace Player
    {
        public class PlayerMove : MonoBehaviour
        {
            [SerializeField, Range(0, 50)]//0から50までの値をインスペクターでいじれるようになる
            private float _speed = 0;
            private IInputer _input = new NullInputer();//iinputerを作成　何も値入ってない
            private Rigidbody2D _rb2d = null;//ADDforce用RB

            void Start()
            {
                _rb2d = GetComponent<Rigidbody2D>();
                _input = MyUtility.Locator<IInputer>.GetT();//ロケーターを使用して値が入ったIInputerを取得
            }

            void Update()
            {
                // 地上でグラビティが1.0、それ以外は0.0にするプログラムを書きたい
            }

            private void FixedUpdate()
            {
                float addXSpeed = (_input.HoriMoveDir() * _speed);//実際に動かす
                float addYSpeed = (_input.VertMoveDir() * _speed);

                _rb2d.velocity = new Vector2(addXSpeed, addYSpeed);
            }
        }
    }
}

