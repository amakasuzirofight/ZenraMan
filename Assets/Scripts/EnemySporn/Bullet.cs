using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    float PlPosx;
    // Start is called before the first frame update
    void Start()
    {
        PlPosx = GameObject.Find("Player").transform.position.x;
        if(transform.position.x<=PlPosx)
        {
            speed *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed, transform.position.y, 0);
    }
}
