using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zenra
{
    public class KatoDebugScript : MonoBehaviour
    {
        
        private void Awake()
        {
            Player.PlayerClimb pc = new Player.PlayerClimb();
            MyUtility.Locator<Player.IObjectTouchable>.Bind(pc, 2);
            MyUtility.Locator<Player.IObjectExecutable>.Bind(pc, 1);
        }

        void Start()
        {

        }

        
        void Update()
        {

        }
    }
}

