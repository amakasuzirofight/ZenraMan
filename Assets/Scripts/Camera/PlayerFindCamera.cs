using UnityEngine;

public class PlayerFindCamera : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<MainCameraMover>().SetTarget(transform);
    }
}
