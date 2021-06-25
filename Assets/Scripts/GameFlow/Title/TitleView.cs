using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Inputer;

namespace Zenra
{
    namespace Title
    {
        public class TitleView : MonoBehaviour
        {
            [SerializeField] Animator animator = null;

            private TitleCore titleCore = null;
            private IInputer input = null;

            private void Awake()
            {
                titleCore = MyUtility.Locator<TitleCore>.GetT();
                input = MyUtility.Locator<IInputer>.GetT();
                animator.Play("ShowTitle");
            }

            private void Update()
            {
                if(input.IsItemButtonDown())
                {
                    titleCore.LoadStageSelectScene();
                }
            }
        }
    }
}