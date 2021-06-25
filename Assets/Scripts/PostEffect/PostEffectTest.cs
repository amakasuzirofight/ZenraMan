using UnityEngine;
using Zenject;
using Zenra.PostEffect;

public class PostEffectTest : MonoBehaviour
{
    [Inject] PostEffect postEffect;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            postEffect.SimpleFade(1, Color.black, PostEffect.FadeType.In);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            postEffect.SimpleFade(1, Color.black, PostEffect.FadeType.Out);
        }
    }
}
