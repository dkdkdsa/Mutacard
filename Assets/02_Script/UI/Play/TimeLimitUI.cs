using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class TimeLimitUI : MonoBehaviour
{

    [SerializeField] private TMP_Text timeText;

    private TMP_Text plusText;
    private LanguageData data = new();

    private void Awake()
    {

        plusText = timeText.transform.Find("PlusText").GetComponent<TMP_Text>();

        data.AddText(LanguageType.KOR, "제한 시간");
        data.AddText(LanguageType.ENG, "Time limit");

    }

    private void Start()
    {

        TimerManager.Instance.OnTimeChangedEvent += HandleTimeChanged;
        TimerManager.Instance.OnTimeAddEvent += GetValueEffect;
    }

    private void HandleTimeChanged(float obj)
    {

        timeText.text = $"{(float)Math.Round(obj, 2)}";

    }

    private void GetValueEffect(float value)
    {
        plusText.text = $"+{(float)Math.Round(value, 2)}";

        Sequence seq = DOTween.Sequence();

        seq.Append(plusText.transform.DOScale(Vector3.one * 1.5f, 0.2f)).SetEase(Ease.InQuad);
        seq.Append(plusText.transform.DOScale(Vector3.one * 1, 0.2f)).SetEase(Ease.OutQuad);
        seq.OnComplete(() => { plusText.text = ""; });
    }


}
