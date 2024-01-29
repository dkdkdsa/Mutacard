using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPack : MonoBehaviour
{

    [SerializeField] private List<Card> includeCards;
    [SerializeField] private int numOfCard;

    private void Start()
    {
        TimerManager.Instance.OnTimeOutEvent += HandleTimeOut;
    }

    private void HandleTimeOut(float obj)
    {

        Destroy(gameObject);

    }

    private void OnDestroy()
    {

        TimerManager.Instance.OnTimeOutEvent -= HandleTimeOut;

    }

    private void OnMouseDown()
    {

        AudioManager.Instance.StartSfx("CardPop");

        for(int i = 0; i < numOfCard; i++)
        {

            int idx = Random.Range(0, includeCards.Count);

            var obj = Instantiate(includeCards[idx], transform.position, Quaternion.identity);
            NewCard(obj.gameObject);

        }

        Destroy(gameObject);

    }

    private void NewCard(GameObject obj)
    {

        var end = transform.position + (Vector3)Random.insideUnitCircle * (3);
        end.z = 0;

        Sequence seq = DOTween.Sequence();
        seq.Append(obj.transform.DORotate(new Vector3(360 * Random.Range(1, 3), 360 * Random.Range(1, 3)), 0.3f, RotateMode.FastBeyond360).SetEase(Ease.OutQuad));
        seq.Join(obj.transform.DOJumpZ(end, -2, 1, 0.3f).SetEase(Ease.OutQuad));
        seq.AppendCallback(() => obj.transform.position = end);

    }

}
