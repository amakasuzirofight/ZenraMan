using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class MainCameraMover : MonoBehaviour
{
    [SerializeField]
    Transform camera;
    [SerializeField]
    Transform target;
    [SerializeField]
    float xOffset;
    [SerializeField]
    float yOffset;
    [SerializeField]
    float maxXPos;
    [SerializeField]
    float minXPos;
    [SerializeField]
    float maxYPos;
    [SerializeField]
    float minYPos;
    void Start()
    {
        if (camera == null)
        {
            camera = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var temp = target.position;
        temp.x += xOffset;
        temp.y += yOffset;
        temp.x = Clamp(temp.x, minXPos, maxXPos);
        temp.y = Clamp(temp.y, minYPos, maxYPos);
        camera.position = temp;
    }
}
