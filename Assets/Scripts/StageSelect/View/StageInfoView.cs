using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageInfoView : MonoBehaviour
{
    [SerializeField] TMP_Text infoText = null;

    public void SetInfo(string info)
    {
        infoText.text = info;
    }
}
