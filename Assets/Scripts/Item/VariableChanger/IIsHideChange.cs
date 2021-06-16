using System;

namespace Zenra
{
    namespace Item
    {
        interface IIsHideChange
        {
            event Action HideChangeEvent;//Action　delgateで定義してるだけ
        }
    }
}
