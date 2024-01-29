using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class CardMargeData
{

    public CardDataSO targetA, targetB;
    public bool destroyAbleA = true, destroyAbleB = true;
    public Card cardPrefab;

    public List<Card> mutationCards;

}


public class CardManager : MonoBehaviour
{

    [SerializeField] private List<CardMargeData> margeDatas;

    public static CardManager Instance;

    public event Action<int> OnCardMarged;

    private void Awake()
    {
        
        Instance = this;

    }

    public void MargeCard(Card a, Card b)
    {

        var data = margeDatas.Find(x => (x.targetA == a.data && x.targetB == b.data) || (x.targetA == b.data && x.targetB == a.data));

        if (data == null) return;

        var pos = a.transform.position;

        MoneyManager.instance.AddMoney((a.data.rank + b.data.rank) * 5);
        AudioManager.Instance.StartSfx("CardAddit");

        if((a.data == data.targetA && data.destroyAbleA) || (a.data == data.targetB && data.destroyAbleB))
        {

            Destroy(a.gameObject);

        }
        else
        {

            MoveObj(a.gameObject);

        }

        if((b.data == data.targetB && data.destroyAbleB) || (b.data == data.targetA && data.destroyAbleA))
        {

            Destroy(b.gameObject);

        }
        else
        {

            MoveObj(b.gameObject);

        }

        var prob = FieldManager.Instance == null ? 0.5f : FieldManager.Instance.mutationProbability;

        if(Random.value <= prob && data.mutationCards.Count > 0)
        {

            int idx = Random.Range(0, data.mutationCards.Count);

            var obj = Instantiate(data.mutationCards[idx], pos, Quaternion.identity);
            NewCard(obj.gameObject);

            OnCardMarged?.Invoke(data.mutationCards[idx].data.rank);


        }
        else
        {

            var obj = Instantiate(data.cardPrefab, pos, Quaternion.identity);

            NewCard(obj.gameObject);

            OnCardMarged?.Invoke(data.cardPrefab.data.rank);

        }


    }

    private void MoveObj(GameObject obj)
    {

        obj.transform.DOMove(obj.transform.position + (Vector3)Random.insideUnitCircle * (Random.value + 0.5f), 0.3f + Random.value / 5).SetEase(Ease.OutSine);

    }

    private void NewCard(GameObject obj)
    {

        var end = obj.transform.position + (Vector3)Random.insideUnitCircle * (Random.value + 1.5f);
        end.z = 0;

        Sequence seq = DOTween.Sequence();
        seq.Append(obj.transform.DORotate(new Vector3(360 * Random.Range(1, 3), 360 * Random.Range(1, 3)), 0.3f, RotateMode.FastBeyond360).SetEase(Ease.OutQuad));
        seq.Join(obj.transform.DOJumpZ(end, -2, 1, 0.3f).SetEase(Ease.OutQuad));
        seq.AppendCallback(() => obj.transform.position = end);

    }



}
