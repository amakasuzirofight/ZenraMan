using System;

namespace Zenra
{
    namespace Item
    {
        interface IHpChange
        {
            event Action HpChangeEvent;
        }
    }
}