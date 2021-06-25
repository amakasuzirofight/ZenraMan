using UnityEngine;

namespace Zenra
{
    namespace PostEffect
    {
        public interface IGetMaterialData
        {
            Material GetMaterial(PostEffectType type);
        }
    }
}