using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class EncyclopediaSystem : MonoBehaviour
{
    public static EncyclopediaSystem Instance;

    [Header("Prefab")]
    [SerializeField] private EncyclopediaCase dataCase;
    [SerializeField] private CardDataSO[] cardDatas;

    [Header("NormalPanel")]
    [SerializeField] private Transform contentTrs;

    [Header("DataPanel")]
    [SerializeField] private GameObject dataPanel;
    [SerializeField] private Image dataImage;
    [SerializeField] private TextMeshProUGUI dataNameText;
    [SerializeField] private TextMeshProUGUI dataEncyclopediaText;
    [SerializeField] private Button dataExitBtn;

    private void Awake()
    {
        Instance = this; //어짜피 한개의 씬에만 있을놈

        dataExitBtn.onClick.AddListener(PopdownDataPanel);
    }

    private void Start()
    {
        //foreach (EncyclopediaData data in EncyclopediaManager.Instance.encyclopediaDataDick.Values)
        //{
        //    EncyclopediaCase newCase = Instantiate(dataCase, contentTrs);
        //    newCase.data = data;
        //}

        foreach (CardDataSO cardData in cardDatas)
        {
            EncyclopediaCase newCase = Instantiate(dataCase, contentTrs);
            newCase.data = cardData;
        }
    }

    public void PopupDataPanel(CardDataSO data)
    {
        dataPanel.transform.DOMoveY(600, 0.5f);

        dataImage.sprite = data.icon;
        var tex = data.cardName.Text.Replace('\n', ' ');
        dataNameText.text = tex;
        dataEncyclopediaText.text = data.cardExplanation.Text;
    }

    private void PopdownDataPanel()
    {
        dataPanel.transform.DOMoveY(300, 0.5f);
    }
}
