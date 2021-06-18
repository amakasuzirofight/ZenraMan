using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Item
    {
        public class ItemSerector : IUseItem,
            IIsHideChange,IHpMaxHeal,IHpSmallHeal
        {
            public event Action HideChangeEvent;
            public event Action SmallHealEvent;
            public event Action MaxHealEvent;

            void IUseItem.ItemAct(UseItemDS date)
            {
                SerectAct(date.name)();
            }

            private Action SerectAct(ItemName name)
            {
                switch (name)
                {
                    case ItemName.NULL:
                        throw new NullReferenceException();
                    case ItemName.OBON:
                        return HideChangeEvent;
                    case ItemName.NIKUMAN:
                        return SmallHealEvent;
                    case ItemName.KARAGE:
                        return MaxHealEvent;
                    default:
                        throw new ArgumentNullException();
                }
            }
        }
    }
}

