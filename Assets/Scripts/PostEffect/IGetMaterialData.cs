using UnityEngine;

namespace Zenra
{
    namespace PostEffect
    {
        public interface IGetMaterialData
        {
            void SetShader(PostEffectType type, ref Material mat);
        }
    }
}