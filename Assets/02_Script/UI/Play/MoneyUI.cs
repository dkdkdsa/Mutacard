using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{

    [SerializeField] private TMP_Text moneyText;

    private LanguageData data = new();

    private void Awake()
    {

        data.AddText(LanguageType.KOR, "µ·");
        data.AddText(LanguageType.ENG, "Money");

    }

    private void Update()
    {
        string timeValueText = $"{MoneyManager.instance.money}";

        if (50 < MoneyManager.instance.money && MoneyManager.instance.money <= 100)
        {
            timeValueText = $"<color=yellow>{timeValueText}</color>";
        }
        else if (0 < MoneyManager.instance.money && MoneyManager.instance.money <= 50)
        {
            timeValueText = $"<color=grey>{timeValueText}</color>";
        }
        else
        {
            timeValueText = $"<color=black>{timeValueText}</color>";
        }

        moneyText.text = $"{data.Text} : {timeValueText}";

    }


}
