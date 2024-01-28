using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankingPanel : MonoBehaviour
{

    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text text;

    public void SetRanking(int rank, string playerName, int score)
    {

        iconImage.color = rank switch
        {

            1 => Color.yellow,
            2 => Color.gray, 
            3 => new Color32(123, 38, 0, 255),
            _ => Color.white,

        };

        text.text = $"{playerName} : {score}";

    }

}
