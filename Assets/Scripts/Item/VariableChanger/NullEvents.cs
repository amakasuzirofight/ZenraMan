using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Item
    {
        public class NullEvents : IIsHideChange,IHpChange
        {
            public event Action HideChangeEvent;
            public event Action HpChangeEvent;
            public NullEvents()//newすると呼ばれる　クラスと同じ名前にすることで発動する
            {
                HideChangeEvent += NullAction;
                HpChangeEvent += NullAction;
            }
            public void NullAction()
            {
                Debug.LogError("NullObject");
            }
        }
    }
}

