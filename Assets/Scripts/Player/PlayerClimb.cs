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
            private ISendLadderPos _sendLadderPos;
            private Vector2 _ladderPos;

            public PlayerClimb()
            {
                _climbable = MyUtility.Locator<IClimbable>.GetT();
                Debug.Log(_climbable);
                _sendLadderPos = null;
            }

            public void EnterAction(GameObject touchObj)
            {
                _sendLadderPos = touchObj.GetComponent<ISendLadderPos>();
                if (_sendLadderPos != null)
                {
                    Debug.Log("CanClimbêÿÇËë÷Ç¶");
                    _climbable.CanClimb();
                    _ladderPos = new Vector2(_sendLadderPos.SendLadderPosX(), _sendLadderPos.SendLadderPosY());
                }
            }

            public void ExitAction(GameObject touchObj)
            {
                
            }

            public void Execute()
            {

                Debug.Log("2É{É^ÉìâüÇ≥ÇÍÇΩ");

            }
        }

    }
}
