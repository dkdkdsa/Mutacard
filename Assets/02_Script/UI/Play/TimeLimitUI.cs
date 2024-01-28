using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeLimitUI : MonoBehaviour
{

    [SerializeField] private TMP_Text timeText;

    private LanguageData data = new();

    private void Awake()
    {

        data.AddText(LanguageType.KOR, "제한 시간");
        data.AddText(LanguageType.ENG, "Time limit");

    }

    private void Start()
    {

        TimerManager.Instance.OnTimeChangedEvent += HandleTimeChanged;

    }

    private void HandleTimeChanged(float obj)
    {

        timeText.text = $"{data.Text} : {obj}";

    }


}
