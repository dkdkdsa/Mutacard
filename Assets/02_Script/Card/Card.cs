using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum CardType
{

    Item,

}

public abstract class Card : MonoBehaviour
{

    [SerializeField] private LanguageType debugView;

    [field:SerializeField] public CardDataSO data { get; private set; }

    public bool isMovement { get; protected set; }

    protected SpriteRenderer iconRenderer;
    protected TMP_Text nameText;
    protected CardMargeBox margeBox;

    private void Awake()
    {
        
        nameText = transform.Find("NameText").GetComponent<TMP_Text>();
        iconRenderer = transform.Find("Icon").GetComponent<SpriteRenderer>();
        margeBox = GetComponentInChildren<CardMargeBox>();

        HandleLanguageChange();

        LanguageManager.OnLanguageChangeEvent += HandleLanguageChange;

    }

    private void HandleLanguageChange()
    {

        nameText.text = data.cardName.Text;
        iconRenderer.sprite = data.icon;

    }

    private void Update()
    {

        if (isMovement)
        {

            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;

            transform.position = pos;

        }

    }

    private void OnDestroy()
    {

        LanguageManager.OnLanguageChangeEvent -= HandleLanguageChange;

    }

    private void OnMouseDown()
    {

        isMovement = true;

    }

    private void OnMouseUp()
    {
        
        isMovement = false;
        margeBox.CheckMarge();

    }


#if UNITY_EDITOR

    protected virtual void OnValidate()
    {

        if (data == null) return;

        transform.Find("NameText").GetComponent<TMP_Text>().text = data.cardName[debugView];
        transform.Find("Icon").GetComponent<SpriteRenderer>().sprite =data.icon;
        GetComponent<SpriteRenderer>().color = data.cardType switch
        {

            CardType.Item => new Color32(180, 180, 180, 255),
            _ => Color.white,

        };

    }

#endif

}
