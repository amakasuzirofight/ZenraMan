using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtility;

namespace Zenra
{
    namespace Player
    {
        public class PlayerSubTemperature : MonoBehaviour
        {
            IColder colder;
            // Start is called before the first frame update
            void Start()
            {
                colder = Locator<PlayerCore>.GetT();
            }

            // Update is called once per frame
            void Update()
            {
                colder.SubTemperature(1);
            }
        }
    }
}

