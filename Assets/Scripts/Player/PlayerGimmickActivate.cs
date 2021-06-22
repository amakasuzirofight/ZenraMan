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
            public void EnterAction(GameObject touchObj)
            {
                gimmickAction = touchObj.GetComponent<IGimmickAction>();
                Debug.Log("������");
            }
            
            public void ExitAction(GameObject touchObj)
            {
                Debug.Log("�o��");
                if (gimmickAction != touchObj.GetComponent<IGimmickAction>()) return;
                gimmickAction = nullObject;
            }

            public void Execute()
            {
                Debug.Log("�{�^�������ꂽ");
                if (gimmickAction == nullObject) return;
                Debug.Log(gimmickAction.GimmickTypes[0]);
                gimmickAction?.GimmickAction();
                // �����Ƀ{�^���������ꂽ���̏���
            }
        }
    }
}

