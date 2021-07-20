using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Gimmick;

namespace Zenra
{
    namespace Player
    {
        public class PlayerGimmickActivate : IObjectTouchable, IObjectExecutable
        {
            static IGimmickAction nullObject = new NullGimmickAction();
            IGimmickAction gimmickAction = nullObject;
            IChangeVariableGimmick changeVariableGimmick = null;

            public void EnterAction(GameObject touchObj)
            {
                gimmickAction = touchObj.GetComponent<IGimmickAction>();
            }

            public void ExitAction(GameObject touchObj)
            {
                if (gimmickAction != touchObj.GetComponent<IGimmickAction>()) return;
                gimmickAction = nullObject;
            }

            public void Execute(Animator animator)
            {
                gimmickAction ??= nullObject;
                if (gimmickAction == nullObject) return;
                var GimmickTypeList = gimmickAction.GimmickTypes;
                gimmickAction?.GimmickAction();

                if (changeVariableGimmick == null)
                {
                    changeVariableGimmick = MyUtility.Locator<IChangeVariableGimmick>.GetT();
                }
                // ここにボタンが押された時の処理
                foreach (var item in GimmickTypeList)
                {
                    switch (item)
                    {
                        case GimmickType.NULL:
                            Debug.LogError("Null");
                            break;
                        case GimmickType.HIDE:
                            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Squat"))
                            {
                                animator.SetTrigger("StandUp");
                            }
                            else
                            {
                                animator.SetTrigger("Squat");
                            }
                            changeVariableGimmick.SetIsHide();
                            break;
                        case GimmickType.SAVE:
                            Debug.Log("Save");
                            break;
                        case GimmickType.HEAL:
                            Debug.Log("Heal");
                            changeVariableGimmick.SetHealToHp(1);
                            break;
                        case GimmickType.COLD:
                            Debug.Log("Cold");
                            changeVariableGimmick.SetCold(1);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}

