namespace Zenra.WarnningCamera
{
    public delegate void PlayerDiscover();
    interface IWhenWarnningLevelUp
    {
        event PlayerDiscover PlayerDiscoverEvent;
    }
}
