using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaCase : MonoBehaviour
{
    [HideInInspector] public EncyclopediaData data;

    [SerializeField] private Sprite noneSprite;
    private Image caseImage;
    private Button caseBtn;

    private void Start()
    {
        caseImage = GetComponent<Image>();
        caseImage.sprite = noneSprite;
        caseBtn = GetComponent<Button>();
        caseBtn.onClick.AddListener(Popup);

        if (data.isCatch)
            caseImage.sprite = data.dataSprite;
        else
            caseImage.sprite = noneSprite;
    }

    private void Popup()
    {
        if (data == null) return;
        if (!data.isCatch)
        {
            Debug.Log($"{data.dataName}(��)�� ���� �߰ߵ��� ���� ���ϸ�");
            return;
        }

        EncyclopediaSystem.Instance.PopupDataPanel(data);
    }
}
