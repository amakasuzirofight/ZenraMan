using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace PostEffect
    {
        public class PostEffectMaterialDB : MonoBehaviour, IGetMaterialData
        {
            [SerializeField] private PostEffectMaterialData[] datas = null;

            public Material GetMaterial(PostEffectType type)
            {
                foreach (PostEffectMaterialData data in datas)
                {
                    if (type == data.Type)
                    {
                        return data.Material;
                    }
                }
                return null;
            }
        }

        public class PostEffectMaterialData
        {
            [SerializeField] PostEffectType type = PostEffectType.SimpleFade;
            [SerializeField] Material material = null;

            public PostEffectType Type => type;
            public Material Material => material;
        }
    }
}