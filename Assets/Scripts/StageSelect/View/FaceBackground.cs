using MyUtility;
using UnityEngine;

public class FaceBackground : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SpriteRenderer>().material.SetTexture("_FaceTex", Locator<Texture2D>.GetT());
    }
}
