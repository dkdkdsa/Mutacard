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

        if((a.data == data.targetA && data.destroyAbleA) || (a.data == data.targetB && data.destroyAbleB))
        {

            Destroy(a.gameObject);

        }

        if((b.data == data.targetB && data.destroyAbleB) || (b.data == data.targetA && data.destroyAbleA))
        {

            Destroy(b.gameObject);

        }

        var prob = FieldManager.Instance == null ? 0.5f : FieldManager.Instance.mutationProbability;

        if(Random.value > prob)
        {

            Instantiate(data.cardPrefab, pos, Quaternion.identity);
            OnCardMarged?.Invoke(data.cardPrefab.data.rank);

        }
        else
        {

            int idx = Random.Range(0, data.mutationCards.Count);

            Instantiate(data.mutationCards[idx], pos, Quaternion.identity);

            OnCardMarged?.Invoke(data.mutationCards[idx].data.rank);

        }


    }

}
