using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMargeBox : MonoBehaviour
{

    private Card myCard;
    private Card targetCard;

    private void Awake()
    {
        
        myCard = GetComponentInParent<Card>();

    }

    public void CheckMarge()
    {

        if(targetCard != null)
        {

            CardManager.Instance.MargeCard(myCard, targetCard);

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("MargeBox"))
        {

            targetCard = collision.transform.GetComponentInParent<Card>();

        }
        else
        {

            targetCard = null;

        }

    }

}
