using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EncyclopediaSystem : MonoBehaviour
{
    public static EncyclopediaSystem Instance;

    private Dictionary<string, EncyclopediaCase> encyclopediaDataDick = new Dictionary<string, EncyclopediaCase>();

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
        Instance = this;

        dataExitBtn.onClick.AddListener(PopdownDataPanel);
    }

    private void Start()
    {
        foreach (EncyclopediaData data in Resources.LoadAll<EncyclopediaData>("EncyclopediaData"))
        {
            EncyclopediaCase newCase = Instantiate(dataCase, contentTrs);
            newCase.data = data;
            encyclopediaDataDick[data.dataName] = newCase;
        }
    }

    public void RegistrationData(string dataName)
    {
        if (!encyclopediaDataDick.ContainsKey(dataName))
        {
            Debug.Log($"{dataName}(은)는 도감에는 존재하지 않는 포켓몬");
            return;
        }

        encyclopediaDataDick[dataName].Registration();
    }

    public void PopupDataPanel(EncyclopediaData data)
    {
        dataPanel.SetActive(true);
        dataImage.sprite = data.dataSprite;
        dataNameText.text = data.dataName;
        dataEncyclopediaText.text = data.dataExplanation;
    }

    private void PopdownDataPanel()
    {
        dataPanel.SetActive(false);
    }
}
