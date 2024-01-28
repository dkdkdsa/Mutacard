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

        moneyText.text = $"{data.Text} : {MoneyManager.instance.money}";

    }


}
