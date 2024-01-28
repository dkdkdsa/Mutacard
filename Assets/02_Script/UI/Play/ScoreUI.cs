using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;

    private LanguageData data = new();

    private void Awake()
    {

        data.AddText(LanguageType.KOR, "Á¡¼ö");
        data.AddText(LanguageType.ENG, "Score");

    }

    private void Update()
    {

        scoreText.text = $"{data.Text} : {ScoreManager.Instance.Score}";

    }

}
