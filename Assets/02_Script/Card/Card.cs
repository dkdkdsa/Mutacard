using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum CardType
{

    Item,

}

[Serializable]
public class CardMargeData
{

    public CardDataSO targetData;
    public Card cardPrefab;

}

public abstract class Card : MonoBehaviour
{

    [SerializeField] private LanguageType debugView;
    [SerializeField] private List<CardMargeData> margeDatas;

    [field:SerializeField] public CardDataSO data { get; private set; }

    protected SpriteRenderer iconRenderer;
    protected TMP_Text nameText;

    private void Awake()
    {
        
        nameText = transform.Find("NameText").GetComponent<TMP_Text>();
        iconRenderer = transform.Find("Icon").GetComponent<SpriteRenderer>();

        HandleLanguageChange();

        LanguageManager.OnLanguageChangeEvent += HandleLanguageChange;

    }

    private void HandleLanguageChange()
    {

        nameText.text = data.cardName.Text;
        iconRenderer.sprite = data.icon;

    }

    private void OnDestroy()
    {

        LanguageManager.OnLanguageChangeEvent -= HandleLanguageChange;

    }


#if UNITY_EDITOR

    protected virtual void OnValidate()
    {

        if (data == null) return;

        transform.Find("NameText").GetComponent<TMP_Text>().text = data.cardName[debugView];
        transform.Find("Icon").GetComponent<SpriteRenderer>().sprite =data.icon;

    }

#endif

}
