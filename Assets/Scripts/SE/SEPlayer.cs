using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zenra.SE;
public class SEPlayer:MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            SeManager.PlaySe("bomb");
        }
    }
}
