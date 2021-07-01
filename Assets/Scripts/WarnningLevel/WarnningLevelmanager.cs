using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtility;
public class WarnningLevelmanager : MonoBehaviour,IWhenWarnningLevelUp
{
    public event PlayerDiscover PlayerDiscoverEvent;
    IPlayerOn PlayerOn;
    
    int WarnningLevel;
    void Start()
    {











        PlayerOn = Locator<IPlayerOn>.GetT();
        WarnningLevel = 0;
    }

    void Update()
    {
        
    }
}
