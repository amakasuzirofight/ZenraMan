using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Gimmick.Ladder;

namespace Zenra
{
    namespace Player
    {
        public class PlayerClimb : IObjectTouchable
        {
            private IClimbable _climbable;
            private Vector2 _ladderPos;

            public PlayerClimb()
            {
                _climbable = MyUtility.Locator<IClimbable>.GetT();
            }

            public void EnterAction(GameObject touchObj)
            {
                var a = touchObj.GetComponent<ISendLadderPos>();
                if(a != null)
                {
                    _climbable.CanClimb();
                    _ladderPos = new Vector2(a.SendLadderPosX(), a.SendLadderPosY());
                }
            }

            public void ExitAction(GameObject touchObj)
            {

            }
        }

    }
}
