public delegate void PlayerDiscover(int level);
interface IWhenWarnningLevelUp
{
    event PlayerDiscover PlayerDiscoverEvent ;
}