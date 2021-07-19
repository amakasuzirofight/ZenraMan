using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.Player;

namespace Zenra
{
    public class DebugDead : MonoBehaviour
    {
        [SerializeField,Tooltip("Player")]
        PlayerDead playerDead;

        void Start()
        {
            
        }

        
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                playerDead.PlayerKill();
            }
        }
    }
}


