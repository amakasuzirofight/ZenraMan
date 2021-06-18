using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Player
    {
        public class PlayerClimb : IObjectTouchable
        {
            private IClimbable _climbable;

            public PlayerClimb()
            {
                _climbable = MyUtility.Locator<IClimbable>.GetT();
            }
           

            public void EnterAction(GameObject touchObj)
            {
                // ‚Æ‚è‚ ‚¦‚¸LadderCore
                var a = touchObj.GetComponent<Gimmick.Ladder.LadderCore>();
                if(a != null)
                {
                    _climbable.CanClimb();
                }
            }

            public void ExitAction(GameObject touchObj)
            {

            }


        }

    }
}
