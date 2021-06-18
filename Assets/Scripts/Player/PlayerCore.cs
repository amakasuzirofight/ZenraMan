﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Item;
//using static Zenra.Item.ItemName;

namespace Zenra
{
    namespace Player
    {
        public class PlayerCore
        {
            private int _hp;//_で変数名を決めておけば_で予測変換が使いやすい　privateで使用されたし
            private List<ItemName> _itemList;
            const int ITEM_LIST_LENGH = 1;//アイテムはひとつしか持てない
            const int MAX_HP = 300;
            private bool _isHide;//かくれているかどうか
            private bool _isClimb;      // はしごに登ってるかどうか

            private IIsHideChange isHideChange = new NullEvents();
            private IHpMaxHeal hpMaxHeal = new NullEvents();
            private IHpSmallHeal hpSmallHeal = new NullEvents();

            public event Action<ItemName> ItemActivation;
            public PlayerCore()
            {
                _isHide = false;
                _hp = MAX_HP;
                _itemList = new List<ItemName>(ITEM_LIST_LENGH);
                isHideChange = MyUtility.Locator<IIsHideChange>.GetT();//myUtilityとはnamespace名　こういう書き方もできる
                hpMaxHeal = MyUtility.Locator<IHpMaxHeal>.GetT();
                hpSmallHeal = MyUtility.Locator<IHpSmallHeal>.GetT();
                isHideChange.HideChangeEvent += HideStateChange;
                hpMaxHeal.MaxHealEvent += HpHealMax;
                hpSmallHeal.SmallHealEvent += HpHealSmall;
                //_ = Hoge();　破棄　_=にすると戻り値があってもVoidと同じ処理速度でやってくれるぽい
            }
           
            public bool IsRetentionItem() => _itemList.Count > 0;//アイテムを持っているかどうか

            public ItemName GetItem()
            {
                if (_itemList.Count < 1) return ItemName.NULL;
                return _itemList[0];
            }

            public ItemName UseItem()
            {
                if (_itemList.Count < 1) return ItemName.NULL;
                var temp = _itemList[0];
                _itemList?.RemoveAt(0);//ItemListがnullだったらRemoveAtを実行しない
                return temp;
            }

            public void AddItem(ItemName name)
            {
                if (IsActivate(name))
                {
                    ItemActivation(name);
                    return;
                }
                if (_itemList.Count >= ITEM_LIST_LENGH) return;
                _itemList.Add(name);
            }

            public bool IsActivate(ItemName name)
            {
                if (name == ItemName.KARAGE) return true;
                if (name == ItemName.NIKUMAN) return true;
                return false;
            }

            public void PlayerKill()
            {
                _hp = 0;
                Debug.Log("死んだ");
            }

            private void HideStateChange()
            {
                Debug.Log("隠れる");
                _isHide = false; 
            }

            private void HpHealMax()
            {
                Debug.Log("全回復");
                _hp = MAX_HP;
            }

            private void HpHealSmall()
            {
                const int HEAL_AMOUNT = 100;
                Debug.Log("回復");
                _hp += HEAL_AMOUNT;
            }
        }
    }
}
