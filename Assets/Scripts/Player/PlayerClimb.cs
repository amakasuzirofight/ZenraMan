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
                    _ladderHighestPosY = _sendLadderPos.SendLadderHighestPosY();
                    _ladderLowesrPosY = _sendLadderPos.SendLadderLowestPosY();

                    if (touchNum == 1 && climbing == true)
                    {
                        Debug.Log("二回目触れた");
                        touchNum = 0;
                        climbing = false;
                        _actionClimb = MyUtility.Locator<IActionClimb>.GetT();
                        _actionClimb.actionClimb(false);
                    }
                }
            }

            public void ExitAction(GameObject touchObj)
            {
                if (_sendLadderPos != touchObj.GetComponent<ISendLadderPos>())
                {
                    return;
                }

                //_sendLadderPos = null;
                //_climbable.CannotClimb();

                //_actionClimb = MyUtility.Locator<IActionClimb>.GetT();
                //_actionClimb.actionClimb(false);
            }

            public void Execute()
            {
                if (_sendLadderPos != null)
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
