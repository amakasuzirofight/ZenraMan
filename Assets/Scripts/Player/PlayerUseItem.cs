using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Inputer;
using Zenra.Item;

namespace Zenra
{
    namespace Player
    {
        public class PlayerUseItem : MonoBehaviour
        {
            private IItemUsable _itemUsable = new NullItemUsable();
            private PlayerCore _core = null;
            private IInputer _input = new NullInputer();
            private IUseItem _useItem = new NullUseItem();
            void Start()
            {
                _input = MyUtility.Locator<IInputer>.GetT();
                _core = MyUtility.Locator<PlayerCore>.GetT();
                _useItem = MyUtility.Locator<IUseItem>.GetT();
                _itemUsable = MyUtility.Locator<IItemUsable>.GetT();
                _core.ItemActivation += GetItemToAction;
            }

            void Update()
            {
                if (_input.IsItemButtonDown())
                {
                    if (_itemUsable.GetIsUseItem())
                    {
                        _itemUsable.FinishUseItem();
                    }
                    bool isUseItem = !_itemUsable.GetIsUseItem() && _core.IsRetentionItem();
                    if (isUseItem)
                    {
                        UseItemToAction();
                    }
                }
            }

            private void UseItemToAction()
            {
                UseItemDS useItemDS = new UseItemDS(_core.UseItem());
                _useItem.ItemAct(useItemDS);
            }

            private void GetItemToAction(ItemName name)
            {
                UseItemDS useItemDS = new UseItemDS(name);
                _useItem.ItemAct(useItemDS);
            }
        }
    }
}

