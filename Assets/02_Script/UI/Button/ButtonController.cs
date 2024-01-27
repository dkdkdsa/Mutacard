using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    private Button _button;
    public UnityEvent OnClick;

    private void Start()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(ButtonClickHandle);
    }

    private void ButtonClickHandle()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOScale(Vector3.one * 0.9f, 0.2f)).SetEase(Ease.OutQuad);
        seq.Append(transform.DOScale(Vector3.one * 1, 0.2f)).SetEase(Ease.OutQuad);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("click?");
        if (_button.interactable)
            OnClick?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
        transform.DOScale(Vector3.one * 1.1f, 0.2f).SetEase(Ease.OutQuad);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
        transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutQuad);
    }
}
