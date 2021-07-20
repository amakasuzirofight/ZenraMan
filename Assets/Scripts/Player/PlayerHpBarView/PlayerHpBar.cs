using MyUtility;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenra.Player;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField] Gradient face_gradient = null;
    [SerializeField] Gradient gradient = null;
    [SerializeField] Slider hpBar = null;
    [SerializeField] Image sliderImage = null;
    [SerializeField] RawImage faceImage = null;
    [SerializeField] TMP_Text text = null;

    private PlayerCore core;

    private void Start()
    {
        core = Locator<PlayerCore>.GetT();
        core.HpChangeAction += ValidateBar;
        faceImage.texture = Locator<Texture2D>.GetT();
    }

    private void ValidateBar(int i)
    {
        float value = (float)i / PlayerCore.MAX_HP;

        if (value < 0f)
        {
            text.text = "“€Ž€‚µ‚½";
        }
        else
        if (value < 0.25f)
        {
            text.text = "“€‚¦Ž€‚ÊI";
        }
        else
        if(value < 0.5f)
        {
            text.text = "Š¦‚¢";
        }
        else
        if (value < 0.75f)
        {
            text.text = "—Á‚µ‚¢";
        }
        else
        if (value < 1f)
        {
            text.text = "“K‰·";
        }
        hpBar.value = value;
        Color c = gradient.Evaluate(value);
        text.color = c;
        sliderImage.color = c;
        faceImage.color = face_gradient.Evaluate(value);
    }
}
