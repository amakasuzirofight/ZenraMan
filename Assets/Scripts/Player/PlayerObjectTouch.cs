using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Inputer;
// enum�ȗ����̂���
using static Zenra.Player.PlayerObjectTouch.ExecutableId;

namespace Zenra
{
    namespace Player
    {
        public class PlayerObjectTouch : MonoBehaviour
        {
            private List<IObjectTouchable> _touchables = new List<IObjectTouchable>();
            private IObjectExecutable _gimmickExecutable;
            private IObjectExecutable _ladderExecutable;
            private IInputer _inputer = new NullInputer();
            [SerializeField]
            Animator Animator;
            [SerializeField]
            SpriteRenderer spriteRenderer;
            [SerializeField]
            Canvas canvas;

            public enum ExecutableId
            {
                GIMMICK,
                LADDER,
            }
            private void Start()
            {
                _touchables.Add(MyUtility.Locator<IObjectTouchable>.GetT(0));
                _touchables.Add(MyUtility.Locator<IObjectTouchable>.GetT(1));
                _touchables.Add(MyUtility.Locator<IObjectTouchable>.GetT(2));
                _inputer = MyUtility.Locator<IInputer>.GetT();
                _gimmickExecutable = MyUtility.Locator<IObjectExecutable>.GetT((int)GIMMICK);
                _ladderExecutable = MyUtility.Locator<IObjectExecutable>.GetT((int)LADDER);
            }

            private void Update()
            {
                if (_inputer.IsGimmickActivateButtonDown())
                {
                    _gimmickExecutable?.Execute(Animator, spriteRenderer,canvas);
                }
                if (_inputer.IsLadderClimbButtonDown())
                {
                    _ladderExecutable?.Execute(Animator, spriteRenderer,canvas);
                }
            }
            private void OnTriggerEnter2D(Collider2D collision)
            {
                foreach (var item in _touchables)
                {
                    item.EnterAction(collision.gameObject);
                }
            }

            private void OnTriggerExit2D(Collider2D collision)
            {
                foreach (var item in _touchables)
                {
                    item.ExitAction(collision.gameObject);
                }
            }
        }
    }
}

