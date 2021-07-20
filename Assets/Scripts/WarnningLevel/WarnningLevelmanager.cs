using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtility;
using Zenra.WarnningCamera;
namespace Zenra.WarnningManager
{
    public class WarnningLevelmanager : MonoBehaviour,IPoliceSporn
    {
        [SerializeField] GameObject PlayerObj;
        IWhenWarnningLevelUp whenWarnningLevelUp;
        int WarnningLevel;

        public event SpornDe SpornEve;

        void Start()
        {
            whenWarnningLevelUp = PlayerObj.GetComponent<IWhenWarnningLevelUp>();
            whenWarnningLevelUp.PlayerDiscoverEvent +=WarnningLevelUp;
            WarnningLevel = 0;
        }

        void Update()
        {

        }
        public void WarnningLevelUp()
        {
            WarnningLevel++;

        }
        
    }

}
