using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowTitle : MonoBehaviour
{
    [SerializeField] private Image[] images;
    [SerializeField] private float endValue;
    [SerializeField] private float duration;

    private Sequence seq;

    private void Awake()
    {
        seq = DOTween.Sequence();
    }

    private void Start()
    {
        Title(endValue, duration);
    }

    public void Title(float endValue, float duration)
    {
        seq.Append(images[0].rectTransform.DOAnchorPosY(endValue + 52, duration).SetEase(Ease.OutQuad))
            .Join(images[0].DOFade(1, duration))
        .Append(images[1].rectTransform.DOAnchorPosY(endValue + 1.6f, duration).SetEase(Ease.OutQuad))
        .Join(images[1].DOFade(1, duration))
        .Append(images[2].rectTransform.DOAnchorPosY(endValue + 27, duration).SetEase(Ease.OutQuad))
        .Join(images[2].DOFade(1, duration))
        .Append(images[3].rectTransform.DOAnchorPosY(endValue, duration).SetEase(Ease.OutQuad))
        .Join(images[3].DOFade(1, duration))
        .Append(images[4].rectTransform.DOAnchorPosY(endValue + 50.4f, duration).SetEase(Ease.OutQuad))
        .Join(images[4].DOFade(1, duration))
        .Append(images[5].rectTransform.DOAnchorPosY(endValue, duration).SetEase(Ease.OutQuad))
        .Join(images[5].DOFade(1, duration))
        .Append(images[6].rectTransform.DOAnchorPosY(endValue, duration).SetEase(Ease.OutQuad))
        .Join(images[6].DOFade(1, duration))
        .Append(images[7].rectTransform.DOAnchorPosY(endValue + 52, duration).SetEase(Ease.OutQuad))
        .Join(images[7].DOFade(1, duration))
        .Append(images[8].rectTransform.DOAnchorPosY(endValue + 138, 0.01f))
        .Join(images[9].rectTransform.DOAnchorPosY(endValue + 48, 0.01f))
        .AppendInterval(0.4f)
        .Append(images[8].DOFade(1, 1.5f))
        .Join(images[9] .DOFade(1, 1.5f));
    }
}
