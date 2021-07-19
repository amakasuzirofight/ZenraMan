using System;
using UnityEngine;
public interface IWhenPlayerHitCamera
{
    GameObject GetObj();
}
public static class IWhenPlayerHitCameraExpansion
{
    public static void GoEventHitCamera(this IWhenPlayerHitCamera whenPlayerHitCamera, object p)
    {
        whenPlayerHitCamera.GetObj().GetComponent<CameraLightHit>();
    }
}