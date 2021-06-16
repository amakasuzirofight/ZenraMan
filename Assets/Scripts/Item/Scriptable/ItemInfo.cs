using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Item
    {
        [CreateAssetMenu(menuName = "ItemObj")]
        public class ItemInfo : ScriptableObject
        {
            [SerializeField]
            public Sprite sprite;
            [SerializeField]
            public ItemName itemName;
        }
    }
}

