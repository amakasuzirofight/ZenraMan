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

            }

            private void FixedUpdate()
            {
                float addSpeed = (_input.SideMoveDir() * _speed - _rb2d.velocity.x);//実際に動かす
                _rb2d.AddForce(addSpeed * Vector2.right, ForceMode2D.Force);//ForceMode Addforseの機能　impluseが一気に力を加える　Forceが少しずつ加えるこっちupdate向け
            }
        }
    }
}

