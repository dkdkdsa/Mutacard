using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModeSelectBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private TMP_Text text;
    [SerializeField] private LanguageData explainText;

    public void OnPointerEnter(PointerEventData eventData)
    {

        text.text = explainText.Text;

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        text.text = "";

    }

}
