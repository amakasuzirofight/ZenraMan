using UnityEngine;
using Zenject;

namespace Zenra
{
    namespace PostEffect
    {
        public class PostEffectInstaller : MonoInstaller
        {
            [SerializeField] GameObject postEffectCamera;
            public override void InstallBindings()
            {
                Container.Bind<PostEffect>().AsSingle();
                Container.Bind<IGetMaterialData>().To<PostEffectMaterialDB>().FromComponentOn(postEffectCamera).AsCached();
                Container.Bind<IPlayPostEffect>().To<PostEffectCamera>().FromComponentOn(postEffectCamera).AsCached();
            }
        }
    }
}