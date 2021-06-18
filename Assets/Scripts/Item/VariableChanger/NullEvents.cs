using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 0067

namespace Zenra
{
    namespace Item
    {
        public class NullEvents : IIsHideChange, IHpMaxHeal,IHpSmallHeal
        {
            public event Action HideChangeEvent;
            public event Action MaxHealEvent;
            public event Action SmallHealEvent;

            public NullEvents()//newすると呼ばれる　クラスと同じ名前にすることで発動する
            {
                HideChangeEvent += NullAction;
                MaxHealEvent += NullAction;
                SmallHealEvent += NullAction;
            }
            public void NullAction()
            {
                Debug.LogError("NullObject");
            }
        }
    }
}

