using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    namespace Player
    {
        public class PlayerObjectTouch : MonoBehaviour
        {
            IObjectTouchable absorption;
            private void Start()
            {
                absorption = new PlayerItemAbsorption();
            }
            private void OnTriggerEnter2D(Collider2D collision)
            {
                absorption.EnterAction(collision.gameObject);
            }

            private void OnTriggerExit2D(Collider2D collision)
            {
                absorption.ExitAction(collision.gameObject);
            }
        }
    }
}

