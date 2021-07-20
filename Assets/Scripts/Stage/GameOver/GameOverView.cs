using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using Zenra.PostEffect;
using Zenra.SceneManagement;

public class GameOverView : MonoBehaviour
{
    private PostEffector postEffect;

    private bool isDead = false;

    [Inject]
    private void Injection(PostEffector postEffect)
    {
        this.postEffect = postEffect;
    }

    public async void Show()
    {
        Debug.Log("OK");
        if (isDead) return;
        isDead = true;
        gameObject.SetActive(true);
        await UniTask.Delay(1000);
        postEffect.Fade(PostEffectType.BloodFade, 2, Color.red, PostEffector.FadeType.In, DG.Tweening.Ease.Linear);
        await UniTask.Delay(2000);
        await SceneLoader.LoadSceneAsync(Scenes.StageSelect,
            (op) => postEffect.Fade(PostEffectType.BloodFade, 1, Color.red, PostEffector.FadeType.Out, DG.Tweening.Ease.Linear));
    }
}
