using MyUtility;
using UnityEngine;
using UnityEngine.UI;
using Zenra.Player;

namespace Zenra
{
    namespace Item
    {
        public class ItemView : MonoBehaviour
        {
            [SerializeField] Image itemIcon = null;
            [SerializeField] Sprite[] sprites = null;
            
            private void Start()
            {
                Locator<PlayerCore>.GetT().ItemStateChangeEvent += (n) =>
                {
                    Debug.Log(n + "NYUSYU");
                    if (n == ItemName.NULL)
                    {
                        itemIcon.gameObject.SetActive(false);
                    }
                    else
                    {
                        itemIcon.gameObject.SetActive(true);
                        itemIcon.sprite = sprites[(int)n];
                    }
                };
            }
        }
    } 
}