namespace Zenra
{
    namespace Gimmick
    {
        interface IGimmickAction
        {
            GimmickType[] GimmickTypes { get; }
            void GimmickAction();
        }
    }
}
