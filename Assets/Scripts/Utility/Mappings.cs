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
            Locator<IInputer>.Bind(new DebugInputer());
            Locator<IUseItem>.Bind(itemSerector);
            Locator<IIsHideChange>.Bind(itemSerector);
            Locator<IHpChange>.Bind(itemSerector);
            Locator<PlayerCore>.Bind(new PlayerCore());
        }
    }
}

