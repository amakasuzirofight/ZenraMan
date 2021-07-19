using UnityEngine;

public class CameraMoveTest : MonoBehaviour
{
    [SerializeField] float speed = 25;

    private void Update()
    {
        Vector2 dir = Vector2.zero;
        if(Input.GetKey(KeyCode.W))
        {
            dir += new Vector2(0, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir += new Vector2(-1, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += new Vector2(0, -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += new Vector2(1, 0);
        }
        transform.position += (Vector3)dir.normalized * speed;
    }
}