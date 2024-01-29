using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class ScoreUI : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;

    private TMP_Text plusText;
    private LanguageData data = new();

    private void Awake()
    {

        plusText = scoreText;

        data.AddText(LanguageType.KOR, "Á¡¼ö");
        data.AddText(LanguageType.ENG, "Score");

    }

    private void Start()
    {
        ScoreManager.Instance.OnScoreAdded += GetValueEffect;
    }

    private void Update()
    {

        scoreText.text = $"{data.Text} : {ScoreManager.Instance.Score}";

    }

    private void GetValueEffect(int value)
    {
        plusText.text = $"+{value}";

        Sequence seq = DOTween.Sequence();

        seq.Append(plusText.transform.DOScale(Vector3.one * 1.3f, 0.2f)).SetEase(Ease.OutQuad);
        seq.Append(plusText.transform.DOScale(Vector3.one * 1, 0.2f)).SetEase(Ease.OutQuad);
        seq.OnComplete(() => { plusText.text = ""; });
    }

}
