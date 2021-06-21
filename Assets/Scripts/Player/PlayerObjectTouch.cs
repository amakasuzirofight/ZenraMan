using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Player
    {
        public class PlayerObjectTouch : MonoBehaviour
        {
            private List<IObjectTouchable> _touchables = new List<IObjectTouchable>();
           
            private void Start()
            {
                _touchables.Add(MyUtility.Locator<IObjectTouchable>.GetT(0));
            }
            private void OnTriggerEnter2D(Collider2D collision)
            {
                foreach (var item in _touchables)
                {
                    item.EnterAction(collision.gameObject);
                }
            }

            private void OnTriggerExit2D(Collider2D collision)
            {
                foreach (var item in _touchables)
                {
                    item.ExitAction(collision.gameObject);
                }
            }
        }
    }
}

