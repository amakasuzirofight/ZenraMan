using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Player;

namespace Zenra
{
    namespace Result
    {
        public class MyHome : MonoBehaviour
        {
            [SerializeField] StageClearView clearView = null;
            private void OnTriggerEnter2D(Collider2D col)
            {
                if(col.GetComponent<PlayerObjectTouch>())
                {
                    clearView.Show();
                }
            }
        }
    }
}