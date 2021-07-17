using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenra.PostEffect;

public class FindPostEffectCameraInCanvas : MonoBehaviour
{
    private void Awake()
    {
        Canvas c = GetComponent<Canvas>();
        c.renderMode = RenderMode.ScreenSpaceCamera;
        c.worldCamera = FindObjectOfType<PostEffectCamera>().GetComponent<Camera>();
    }
}
