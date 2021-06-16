namespace Zenra
{
    namespace Item
    {
        interface IUseItem
        {
            void ItemAct(UseItemDS date);
        }

        public struct UseItemDS
        {
            public ItemName name;
            public UseItemDS(ItemName name)
            {
                this.name = name;
            }
        }
    }
}
