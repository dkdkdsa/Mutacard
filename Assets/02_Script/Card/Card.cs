using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public enum CardType
{

    Item,
    Production,
    Environment,
    Biology

}

public abstract class Card : MonoBehaviour
{

    [SerializeField] private LanguageType debugView;

    [field:SerializeField] public CardDataSO data { get; private set; }

    public bool isMovement { get; protected set; }

    protected SpriteRenderer mainRanerer;
    protected SpriteRenderer iconRenderer;
    protected TMP_Text nameText;
    protected CardMargeBox margeBox;
    protected Collider col;
    protected SortingGroup group;

    private void Awake()
    {
        
        mainRanerer = GetComponent<SpriteRenderer>();
        nameText = transform.Find("NameText").GetComponent<TMP_Text>();
        iconRenderer = transform.Find("Icon").GetComponent<SpriteRenderer>();
        margeBox = GetComponentInChildren<CardMargeBox>();
        col = GetComponent<Collider>();
        group = GetComponent<SortingGroup>();

        HandleLanguageChange();

        LanguageManager.OnLanguageChangeEvent += HandleLanguageChange;



    }

    protected virtual void Start()
    {

        TimerManager.Instance.OnTimeOutEvent += HandleTimeOut;

    }

    private void HandleTimeOut(float obj)
    {

        Destroy(gameObject);

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

            if (Time.timeScale == 0) return;

            var pos = MousePos();

            transform.position = pos;

        }
        else
        {

            group.sortingOrder = (int)(transform.position.y * 10);

        }


    }

    public Vector3 MousePos()
    {

        Vector3 mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Physics.Raycast(ray, out var info, 100, LayerMask.GetMask("Ground"));

        return info.point;

    }

    private void OnDestroy()
    {

        LanguageManager.OnLanguageChangeEvent -= HandleLanguageChange;
        TimerManager.Instance.OnTimeOutEvent -= HandleTimeOut;

    }

    private void OnMouseEnter()
    {

        mainRanerer.material.SetFloat("_InnerOutlineFade", 1);
       

    }

    private void OnMouseExit()
    {


        mainRanerer.material.SetFloat("_InnerOutlineFade", 0);
        

    }

    private void OnMouseDown()
    {

        isMovement = true;
        col.enabled = false;
        AudioManager.Instance.StartSfx("CardCatch");

        transform.DOKill();

        transform.DOScale(Vector3.one * 1.5f, 0.2f).SetEase(Ease.OutQuad);

        group.sortingOrder = 1000000;

    }

    private void OnMouseUp()
    {
        
        isMovement = false;
        margeBox.CheckMarge();
        col.enabled = true;

        AudioManager.Instance.StartSfx("CardPush");

        transform.DOKill();

        transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.OutQuad);

    }


#if UNITY_EDITOR

    protected virtual void OnValidate()
    {

        if (data == null) return;

        gameObject.name = data.name;
        transform.Find("NameText").GetComponent<TMP_Text>().text = data.cardName[debugView];
        transform.Find("Icon").GetComponent<SpriteRenderer>().sprite =data.icon;
        GetComponent<SpriteRenderer>().color = data.cardType switch
        {

            CardType.Item => new Color32(180, 180, 180, 255),
            CardType.Production => new Color32(192, 255, 175, 255),
            CardType.Environment => new Color32(144, 212, 255, 255),
            CardType.Biology => new Color32(255, 234, 165, 255),
            _ => Color.white,

        };

    }

#endif

}
