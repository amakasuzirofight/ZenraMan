using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace StageSelect
    {
        public class StageSelectView : MonoBehaviour
        {
            [SerializeField] StageElementFactory elementFactory = null;
            private void Awake()
            {
                elementFactory.InstantiateAllElements();
            }
        }
    }
}