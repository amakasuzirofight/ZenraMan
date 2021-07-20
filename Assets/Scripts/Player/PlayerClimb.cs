using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Gimmick.Ladder;

namespace Zenra
{
    namespace Player
    {
        public class PlayerClimb : IObjectTouchable, IObjectExecutable
        {
            private IClimbable _climbable;
            private IActionClimb _actionClimb;
            private ISendLadderPos _sendLadderPos;

            private LadderTop ladderTop;
            private LadderBottom ladderBottom;

            private Vector2 _ladderPos;
            private float _ladderHighestPosY;
            private float _ladderLowesrPosY;
            private int touchNum = 0;
            private bool climbing = false;

            public PlayerClimb()
            {
                _climbable = MyUtility.Locator<IClimbable>.GetT();

                _sendLadderPos = null;
            }

            public void EnterAction(GameObject touchObj)
            {
                _sendLadderPos = touchObj.GetComponent<ISendLadderPos>();
                if (_sendLadderPos != null)
                {
                    _climbable.CanClimb();
                    _ladderPos = new Vector2(_sendLadderPos.SendLadderPosX(), _sendLadderPos.SendLadderPosY());

                    if(touchObj.GetComponent<LadderBottom>())
                    {
                        Debug.Log("LadderBottom");
                        _actionClimb = MyUtility.Locator<IActionClimb>.GetT();
                        _actionClimb.changeMoveMode(1);
                    }
                    else if(touchObj.GetComponent<LadderTop>())
                    {
                        Debug.Log("LadderTop");
                        _actionClimb = MyUtility.Locator<IActionClimb>.GetT();
                        _actionClimb.changeMoveMode(2);
                    }
                    else
                    {
                        Debug.Log("Null");
                        _actionClimb = MyUtility.Locator<IActionClimb>.GetT();
                        _actionClimb.changeMoveMode(0);
                    }

                    if (touchNum == 1 && climbing == true)
                    {
                        Debug.Log("二回目触れた");
                        touchNum = 0;
                        climbing = false;
                        _actionClimb = MyUtility.Locator<IActionClimb>.GetT();
                        _actionClimb.actionClimb(false);
                        _actionClimb.changeMoveMode(0);
                    }
                }
            }

            public void ExitAction(GameObject touchObj)
            {
                if (_sendLadderPos != touchObj.GetComponent<ISendLadderPos>())
                {
                    return;
                }

                _sendLadderPos = null;

                if (touchObj.GetComponent<LadderBottom>())
                {
                    Debug.Log("LadderBottom");
                    _actionClimb = MyUtility.Locator<IActionClimb>.GetT();
                    _actionClimb.changeMoveMode(0);
                }
                else if (touchObj.GetComponent<LadderTop>())
                {
                    Debug.Log("LadderTop");
                    _actionClimb = MyUtility.Locator<IActionClimb>.GetT();
                    _actionClimb.changeMoveMode(0);
                }
                else
                {
                    Debug.Log("Null");
                    _actionClimb = MyUtility.Locator<IActionClimb>.GetT();
                    _actionClimb.changeMoveMode(0);
                }

                //_climbable.CannotClimb();

                //_actionClimb = MyUtility.Locator<IActionClimb>.GetT();
                //_actionClimb.actionClimb(false);
            }

            public void Execute(Animator animator,SpriteRenderer spriteRenderer,Canvas canvas)
            {
                if (_sendLadderPos != null && climbing == false)
                {
                    climbing = true;
                    Debug.Log("2ボタン押された");
                    // ここわからん。2ボタン押されたら毎回GetTしちゃうよ
                    _actionClimb = MyUtility.Locator<IActionClimb>.GetT();
                    _actionClimb.shiftPlayerPos(_ladderPos.x);
                    _actionClimb.actionClimb(true);
                    touchNum++;
                }
            }
        }
    }
}
