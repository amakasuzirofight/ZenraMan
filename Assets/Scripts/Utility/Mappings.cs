using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Inputer;
using Zenra.Item;
using Zenra.Player;

namespace MyUtility
{
    public class Mappings
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]//最速で実行される
        private static void CreateMaps()
        {
            GameSceneMap();
        }

        private static void GameSceneMap()
        {
            ItemSerector itemSerector = new ItemSerector();
            PlayerGimmickActivate playerGimmickActivate = new PlayerGimmickActivate();

            Locator<IInputer>.Bind(new DebugInputer());
            Locator<IUseItem>.Bind(itemSerector);
            Locator<IIsHideChange>.Bind(itemSerector);
            Locator<IHpMaxHeal>.Bind(itemSerector);
            Locator<IHpSmallHeal>.Bind(itemSerector);

            PlayerCore playerCore = new PlayerCore();

            Locator<PlayerCore>.Bind(playerCore);
            Locator<IObjectTouchable>.Bind(new PlayerItemAbsorption(),0);
            Locator<IObjectTouchable>.Bind(playerGimmickActivate, 1);
            //Locator<IObjectTouchable>.Bind(ここはしご,2);
            Locator<IItemUsable>.Bind(playerCore);
            Locator<IObjectExecutable>.Bind(playerGimmickActivate, 0);
            //Locator<IObjectExecutable>.Bind(ここはしご, 1);
        }
    }
}

