using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LastScoreUI : MonoBehaviour
{

    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button menuBtn;
    [SerializeField] private LanguageData data;

    private void Start()
    {

        TimerManager.Instance.OnTimeOutEvent += HandleGameEnd;

    }

    private void HandleGameEnd(float obj)
    {
        gameoverPanel.SetActive(true);
        text.text = $"{data.Text} : {ScoreManager.Instance.Score}";
        menuBtn.onClick.AddListener(GotoMenuScene);

        Time.timeScale = 0;
    }

    private void GotoMenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("IntroScene");
    }
}
