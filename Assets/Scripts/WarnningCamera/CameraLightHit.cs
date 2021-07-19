using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLightHit : MonoBehaviour, IWhenWarnningLevelUp

{
    public event PlayerDiscover PlayerDiscoverEvent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IWhenPlayerHitCamera whenPlayerHitCamera = default;
        whenPlayerHitCamera.GoEventHitCamera(this);

        if (collision.gameObject.name == "player")
        {
          
        }
    }
}
