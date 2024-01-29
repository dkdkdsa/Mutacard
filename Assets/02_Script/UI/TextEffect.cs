using DG.Tweening;
using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextEffect : MonoBehaviour
{

    private TMP_Text text;

    private void Awake()
    {
        
        text = GetComponent<TMP_Text>();

    }

    public void Show(string text, Color color)
    {

        this.text.text = text;
        this.text.color = color;

        transform.DOMove(transform.position + new Vector3(0, 2), 0.5f).OnComplete(() =>
        {

            FAED.InsertPool(gameObject);

        });

    }

}
