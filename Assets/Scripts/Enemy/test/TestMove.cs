using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    float turnTime = 3.0f;
    float speed = 3;
    bool canrun = true;
    float timecount;
    void Update()
    {
        if(canrun)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            timecount += Time.deltaTime;
            if(timecount>turnTime)
            {
                canrun = false;
                timecount = 0;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            StartCoroutine("Turn");
        }

        IEnumerator Turn()
        {
            yield return new WaitForSeconds(1f);
            canrun = true;
        }
    }
}
