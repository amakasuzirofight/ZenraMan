using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Item
    {
        [CreateAssetMenu(menuName = "ItemObj")]
        public class ItemObject : ScriptableObject
        {
            [SerializeField]
            private Sprite sprite;
            [SerializeField]
            private ItemName itemName;
        }
    }
}

