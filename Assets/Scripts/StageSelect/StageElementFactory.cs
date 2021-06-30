using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace StageSelect
    {
        public class StageElementFactory : MonoBehaviour
        {
            [SerializeField] StageElementView prefab = null;
            [SerializeField] Transform elementsParent = null;
            [SerializeField] StageElementData[] elementDatas = null;

            public void InstantiateElement(StageElementData data)
            {
                StageElementView instance = Instantiate(prefab, elementsParent);
                ((IStageElementInitalize)instance).Initalize(data);
            }

            public void InstantiateAllElements()
            {
                foreach (StageElementData data in elementDatas)
                {
                    InstantiateElement(data);
                }
            }
        }
    }
}