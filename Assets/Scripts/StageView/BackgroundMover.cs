using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] float horizontalMove = 0.1f;
    [SerializeField] float verticalMove = 0f;

    private Transform cameraTransform;
    private Vector2 startPos;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
        startPos = transform.position;
    }

    private void Update()
    {
        float x = Mathf.Lerp(startPos.x, cameraTransform.position.x, horizontalMove);
        float y = Mathf.Lerp(startPos.y, cameraTransform.position.y, verticalMove);

        transform.position = new Vector3(x, y, transform.position.z);
    }

}
