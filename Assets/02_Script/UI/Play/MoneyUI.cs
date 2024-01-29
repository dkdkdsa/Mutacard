using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class MoneyUI : MonoBehaviour
{

    [SerializeField] private TMP_Text moneyText;

    private TMP_Text plusText;
    private LanguageData data = new();

    private void Awake()
    {

        plusText = moneyText;

        data.AddText(LanguageType.KOR, "µ·");
        data.AddText(LanguageType.ENG, "Money");

        MoneyManager.instance.OnMoneyAddEvent += GetValueEffect;

    }

    private void Update()
    {

        moneyText.text = $"{data.Text} : {MoneyManager.instance.money}";

    }

    private void GetValueEffect(float value)
    {
        plusText.text = $"+{value}";

        Sequence seq = DOTween.Sequence();

        seq.Append(plusText.transform.DOScale(Vector3.one * 1.3f, 0.2f)).SetEase(Ease.OutQuad);
        seq.Append(plusText.transform.DOScale(Vector3.one * 1, 0.2f)).SetEase(Ease.OutQuad);
        seq.OnComplete(() => { plusText.text = ""; });
    }
}
