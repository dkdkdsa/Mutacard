using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaCase : MonoBehaviour
{
    [HideInInspector] public bool isCatch;
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
    }

    private void Popup()
    {
        if (data == null) return;
        if (!isCatch)
        {
            Debug.Log($"{data.dataName}(은)는 아직 발견되지 못한 포켓몬");
            return;
        }

        EncyclopediaSystem.Instance.PopupDataPanel(data);
    }

    public void Registration()
    {
        isCatch = true;
        caseImage.sprite = data.dataSprite;
    }
}
