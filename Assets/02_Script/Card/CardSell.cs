using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSell : MonoBehaviour
{

    private Card targetCard;

    private void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {

            if(targetCard != null)
            {

                MoneyManager.instance.AddMoney(targetCard.data.rank * 3);
                Destroy(targetCard.gameObject);
                FAED.TakePool<TextEffect>("TEF", transform.position + Vector3.one).Show($"{targetCard.data.rank * 3}$", Color.yellow);

            }

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
