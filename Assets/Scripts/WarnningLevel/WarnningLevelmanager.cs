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
        PlayerOn.OnlightEvent += LevelUp;
        WarnningLevel = 0;
    }

    void Update()
    {
        
    }
    public void LevelUp()
    {
        WarnningLevel++;
    }
}
