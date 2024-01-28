using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LastScoreUI : MonoBehaviour
{

    [SerializeField] private TMP_Text text;
    [SerializeField] private LanguageData data;

    private void Start()
    {

        TimerManager.Instance.OnTimeOutEvent += HandleGameEnd;

    }

    private void HandleGameEnd(float obj)
    {

        text.text = $"{data.Text} : {ScoreManager.Instance.Score}";

    }

}
