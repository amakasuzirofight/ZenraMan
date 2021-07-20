using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class MainCameraMover : MonoBehaviour
{
    [SerializeField]
    Transform camera = null;
    [SerializeField]
    Transform target = null;
    [SerializeField]
    float xOffset = 0;
    [SerializeField]
    float yOffset = 0;
    [SerializeField]
    float maxXPos = 0;
    [SerializeField]
    float minXPos = 0;
    [SerializeField]
    float maxYPos = 0;
    [SerializeField]
    float minYPos = 0;
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
        if (target == null) return;
        var temp = target.position;
        temp.x += xOffset;
        temp.y += yOffset;
        temp.x = Clamp(temp.x, minXPos, maxXPos);
        temp.y = Clamp(temp.y, minYPos, maxYPos);
        camera.position = temp;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void SetOffset(float x, float y)
    {
        xOffset = x;
        yOffset = y;
    }

    public void SetMinPos(float x, float y)
    {
        minXPos = x;
        minYPos = y;
    }

    public void SetMaxPos(float x, float y)
    {
        maxXPos = x;
        maxYPos = y;
    }
}
