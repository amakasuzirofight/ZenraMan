using UnityEngine;

public class PlayerFindCamera : MonoBehaviour
{
    private void Awake()
    {
        MainCameraMover cameraMover = FindObjectOfType<MainCameraMover>();
        cameraMover.SetTarget(transform);
        cameraMover.SetOffset(0, 35);
        cameraMover.SetMinPos(0, 0);
        cameraMover.SetMaxPos(1000, 1000);
    }
}
