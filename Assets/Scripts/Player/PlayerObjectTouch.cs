using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Player
    {
        public class PlayerObjectTouch : MonoBehaviour
        {
            PlayerItemAbsorption absorption;
            private void Start()
            {
                absorption = new PlayerItemAbsorption();
            }
            private void OnTriggerEnter2D(Collider2D collision)
            {
                var components = collision.gameObject.GetComponents<MonoBehaviour>();
                foreach (var component in components)
                {
                    if (component is IItemAbsorption item)
                    {
                        absorption.EnterAction(item);
                    }
                }
            }

            private void OnTriggerExit2D(Collider2D collision)
            {

            }
        }
    }
}

