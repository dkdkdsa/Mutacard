using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPack : MonoBehaviour
{

    [SerializeField] private List<Card> includeCards;
    [SerializeField] private int numOfCard;

    private void OnMouseDown()
    {

        for(int i = 0; i < numOfCard; i++)
        {

            int idx = Random.Range(0, includeCards.Count);

            Instantiate(includeCards[idx], transform.position, Quaternion.identity);

        }

        Destroy(gameObject);

    }

}
