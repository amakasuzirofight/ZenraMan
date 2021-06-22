using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliMove : MonoBehaviour
{
    PoliMove()
    {

    }

    Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {

    }
    public void Move(float speed)
    {
        _rb.velocity = new Vector2(speed, _rb.velocity.y);
    }
    public void StopMove()
    {
        _rb.velocity = default;
    }
    public void Turn()
    {
        //アニメーションはさんだ後に呼ばれる
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
