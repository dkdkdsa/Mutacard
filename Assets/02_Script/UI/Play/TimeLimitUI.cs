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

        plusText = timeText.GetComponentInChildren<TMP_Text>();

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

        timeText.text = $"{data.Text} : {obj}";

    }

    private void GetValueEffect(float value)
    {
        plusText.text = $"+{value}";

        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOScale(Vector3.one * 1.3f, 0.2f)).SetEase(Ease.OutQuad);
        seq.Append(transform.DOScale(Vector3.one * 1, 0.2f)).SetEase(Ease.OutQuad);
    }


}
