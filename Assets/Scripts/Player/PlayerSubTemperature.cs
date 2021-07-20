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
            IEnumerator Start()
            {
                colder = Locator<PlayerCore>.GetT();
                while (true)
                {
                    yield return new WaitForSeconds(2f);
                    colder.SubTemperature(1);
                }
            }

            // Update is called once per frame
            void Update()
            {
                
            }
        }
    }
}

