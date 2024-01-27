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

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("MargeBox"))
        {

            targetCard = other.transform.GetComponentInParent<Card>();

        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("MargeBox"))
        {

            targetCard = null;

        }


    }

}
