using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{

    public int money;

    public bool Buy(int price)
    {

        if (money < price) return false;

        money -= price;

        return true;

    }

}
