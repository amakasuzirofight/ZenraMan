using Menu;
using UnityEngine;

namespace Zenra
{
    namespace StageSelect
    {
        public class StageElementFactory : MonoBehaviour
        {
            [SerializeField] StageElementView prefab = null;
            [SerializeField] Transform elementsParent = null;
            [SerializeField] MenuContext menu = null;
            [SerializeField] StageInfoView stageInfoView = null;
            [SerializeField] StageElementData[] elementDatas = null;

            public void InstantiateElement(StageElementData data)
            {
                StageElementView instance = Instantiate(prefab, Vector3.zero, Quaternion.identity, elementsParent);
                instance.SelectedAction.AddListener(() => stageInfoView.SetInfo(data.Info));
                instance.Initalize(data);
                menu.AddChild(instance);
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