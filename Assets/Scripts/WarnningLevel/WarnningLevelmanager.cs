using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtility;
using Zenra.WarnningCamera;
namespace Zenra.WarnningManager
{
    public class WarnningLevelmanager : MonoBehaviour
    {
        [SerializeField] GameObject PlHitWCamera;
        IWhenWarnningLevelUp whenWarnningLevelUp;
        int WarnningLevel;
        void Start()
        {
            whenWarnningLevelUp = PlHitWCamera.GetComponent<IWhenWarnningLevelUp>();
            PlHitWCamera.play
            WarnningLevel = 0;
        }

        void Update()
        {

        }

    }

}
