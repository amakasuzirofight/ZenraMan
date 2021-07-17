using UnityEngine;
using Zenject;

namespace Zenra
{
    namespace PostEffect
    {
        public class PostEffectorInstaller : MonoInstaller
        {
            [SerializeField] GameObject postEffectCamera;
            public override void InstallBindings()
            {
                Container.Bind<PostEffector>().AsSingle();
                //Container.Bind<IGetMaterialData>().To<PostEffectMaterialDB>().FromComponentOn(postEffectCamera).AsCached();
                Container.Bind<IGetMaterialData>().To<PostEffectMaterialDB>().FromComponentInNewPrefab(postEffectCamera).AsSingle();
            }
        }
    }
}