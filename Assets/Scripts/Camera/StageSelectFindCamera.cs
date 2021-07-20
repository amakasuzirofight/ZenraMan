using UnityEngine;

public class StageSelectFindCamera : MonoBehaviour
{
    private void Awake()
    {
        MainCameraMover cameraMover = FindObjectOfType<MainCameraMover>();
        cameraMover.SetTarget(transform);
        cameraMover.SetOffset(0, 0);
        cameraMover.SetMinPos(0, 0);
        cameraMover.SetMaxPos(1000, 1000);
    }
}
