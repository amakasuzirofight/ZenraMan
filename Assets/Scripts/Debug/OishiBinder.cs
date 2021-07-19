using MyUtility;
using UnityEngine;

public class OishiBinder : MonoBehaviour
{
    [SerializeField] Texture2D Oishi = null;
    public void Awake()
    {
        Locator<Texture2D>.Bind(Oishi);
    }
}
