using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoliceCamera
{
    public class WarningCamera : MonoBehaviour, IPlayerOn
    {

        bool isHiter;

        public event OnLight OnlightEvent;

        // Start is called before the first frame update
        void Start()
        {
            isHiter = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name != "Player") return;
            if (!isHiter)
            {
                OnlightEvent();
                isHiter = true;
            }

        }
    }

}
