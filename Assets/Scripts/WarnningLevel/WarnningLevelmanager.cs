using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtility;
namespace Zenra.WarnningManager
{
    public class WarnningLevelmanager : MonoBehaviour
    {
        [SerializeField] GameObject PlHitWCamera;

        int WarnningLevel;
        void Start()
        {
            WarnningLevel = 0;
        }

        void Update()
        {

        }

    }

}
