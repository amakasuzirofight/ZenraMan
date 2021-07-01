using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Zenra.Inputer;

namespace Zenra
{
    namespace Title
    {
        public class TitleView : MonoBehaviour
        {
            [SerializeField] Animator animator = null;

            private IInputer input = null;

            
            private async void Awake()
            {
                input = MyUtility.Locator<IInputer>.GetT();
                animator.Play("ShowTitle");

                await UniTask.WaitUntil(() => input.IsItemButtonDown());
                new TitleCore().LoadStageSelectScene();
            }
        }
    }
}