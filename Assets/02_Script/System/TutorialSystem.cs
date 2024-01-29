using DG.Tweening;
using FD.Dev;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[System.Serializable]
public class TutorialTextObject
{

    public string key;
    public List<LanguageData> texts;
    public UnityEvent OnCompleteEvent;

}

public class TutorialSystem : MonoBehaviour
{

    [SerializeField] private List<TutorialTextObject> texts;
    [SerializeField] private TMP_Text tutorialText;
    [SerializeField] private GameObject panel;

    private void Start()
    {

        ShowText("Start");

    }

    public void ShowText(string key)
    {

        var obj = texts.Find(x => x.key == key);
        StartCoroutine(TextSetCo(obj));

    }

    private IEnumerator TextSetCo(TutorialTextObject obj)
    {

        panel.SetActive(true);

        foreach(var text in obj.texts)
        {

            bool comp = false;
            var co = StartCoroutine(TextSettingCO(text.Text, () => comp = true));

            yield return new WaitUntil(() => { return comp || Input.GetMouseButtonDown(0); });

            tutorialText.text = text.Text;
            StopCoroutine(co);

            yield return null;

            yield return new WaitUntil(() => { return Input.GetMouseButtonDown(0); });

            yield return null;

        }

        obj.OnCompleteEvent?.Invoke();

        panel.SetActive(false);

    }

    public void AddMargeToStart()
    {

        CardManager.Instance.OnCardMarged += HandleCardMarge;

    }

    public void AddMargeToStartMut()
    {

        CardManager.Instance.OnCardMarged += HandleCardMargeMut;

    }

    private void HandleCardMargeMut(int obj)
    {


        FAED.InvokeDelay(() =>
        {

            ShowText("Trd");
            CardManager.Instance.OnCardMarged -= HandleCardMargeMut;

        }, 3f);


    }

    public void End()
    {

        SceneManager.LoadScene("IntroScene");

    }

    private void HandleCardMarge(int obj)
    {

        FAED.InvokeDelay(() =>
        {


            ShowText("Sec");
            CardManager.Instance.OnCardMarged -= HandleCardMarge;

        }, 3f);


    }

    public void NewCard(GameObject perfab)
    {

        var obj = Instantiate(perfab);

        var end = (Vector3)Random.insideUnitCircle * (3);
        end.z = 0;

        Sequence seq = DOTween.Sequence();
        seq.Append(obj.transform.DORotate(new Vector3(360 * Random.Range(1, 3), 360 * Random.Range(1, 3)), 0.3f, RotateMode.FastBeyond360).SetEase(Ease.OutQuad));
        seq.Join(obj.transform.DOJumpZ(end, -2, 1, 0.3f).SetEase(Ease.OutQuad));
        seq.AppendCallback(() => obj.transform.position = end);

    }

    private IEnumerator TextSettingCO(string text, Action compEvent)
    {

        tutorialText.text = string.Empty;

        foreach (var ch in text)
        {

            tutorialText.text += ch;
            yield return new WaitForSeconds(0.05f);

        }

        compEvent?.Invoke();

    }

}
