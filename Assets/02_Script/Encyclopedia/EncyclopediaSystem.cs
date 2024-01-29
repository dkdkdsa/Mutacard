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
        foreach (EncyclopediaData data in EncyclopediaManager.Instance.encyclopediaDataDick.Values)
        {
            EncyclopediaCase newCase = Instantiate(dataCase, contentTrs);
            newCase.data = data;
        }
    }

    public void PopupDataPanel(EncyclopediaData data)
    {
        dataPanel.transform.DOMoveY(950, 0.5f);

        dataImage.sprite = data.dataSprite;
        dataNameText.text = data.dataName;
        dataEncyclopediaText.text = data.dataExplanation;
    }

    private void PopdownDataPanel()
    {
        dataPanel.transform.DOMoveY(700, 0.5f);
    }
}
