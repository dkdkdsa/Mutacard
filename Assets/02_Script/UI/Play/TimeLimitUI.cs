using System.Collections;
using TMPro;
using UnityEngine;

public class TimeLimitUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text PlustimeText;
    private LanguageData data = new();

    private void Awake()
    {
        data.AddText(LanguageType.KOR, "제한 시간");
        data.AddText(LanguageType.ENG, "Time limit");

        // 처음에 PlustimeText를 비활성화
        PlustimeText.gameObject.SetActive(false);
    }

    private void Start()
    {
        TimerManager.Instance.OnTimeChangedEvent += HandleTimeChanged;
        TimerManager.Instance.OnTimeAddEvent += HandleTimeAdded;
    }

    private void HandleTimeAdded(float obj)
    {
        PlustimeText.text = "+"+obj.ToString("0.##");

        PlustimeText.gameObject.SetActive(true);
        StartCoroutine(AnimatePlusTimeText());
    }

    private void HandleTimeChanged(float obj)
    {
        string timeLimitText = $"{data.Text} : ";
        string timeValueText = obj.ToString("0.##");

        if (20 < obj && obj <= 40)
        {
            timeValueText = $"<color=yellow>{timeValueText}</color>";
        }
        else if (obj <= 20)
        {
            timeValueText = $"<color=red>{timeValueText}</color>";
        }
        else
        {
            timeValueText = $"<color=green>{timeValueText}</color>";
        }

        timeText.text = timeLimitText + timeValueText;
    }

    private IEnumerator AnimatePlusTimeText()
    {
        float scaleFactor = 1.5f;
        float duration = 0.3f;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float scale = Mathf.Lerp(1f, scaleFactor, t / duration);
            PlustimeText.transform.localScale = Vector3.one * scale;
            yield return null;
        }

        PlustimeText.transform.localScale = Vector3.one * scaleFactor;

        yield return new WaitForSeconds(0.3f);

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float scale = Mathf.Lerp(scaleFactor, 1f, t / duration);
            PlustimeText.transform.localScale = Vector3.one * scale;
            yield return null;
        }

        PlustimeText.transform.localScale = Vector3.one;

        PlustimeText.gameObject.SetActive(false);
    }
}
