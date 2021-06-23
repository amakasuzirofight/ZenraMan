namespace Zenra
{
    namespace KillLight
    {
        public delegate void LightHitdelegate();
        public delegate void LightExitdelegate();
        public interface ILightHit
        {
             event LightHitdelegate LightHitEvent;
            event LightExitdelegate LightExitEvent;
        }
    }
}
