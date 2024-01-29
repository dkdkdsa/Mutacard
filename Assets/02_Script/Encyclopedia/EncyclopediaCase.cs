using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaCase : MonoBehaviour
{
    [HideInInspector] public CardDataSO data;

    private Image caseImage;
    private Button caseBtn;

    private void Start()
    {
        caseImage = GetComponent<Image>();
        caseBtn = GetComponent<Button>();
        caseBtn.onClick.AddListener(Popup);

        caseImage.sprite = data.icon;
    }

    private void Popup()
    {
        if (data == null) return;

        EncyclopediaSystem.Instance.PopupDataPanel(data);
    }
}
