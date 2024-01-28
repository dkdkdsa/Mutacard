using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{

    public static MoneyManager instance;

    public event Action<float> OnMoneyAddEvent;

    private void Awake()
    {
        
        instance = this;

    }

    public int money { get; private set; }

    public void AddMoney(int money)
    {

        this.money += money;
        OnMoneyAddEvent?.Invoke(money);

    }

    public bool Buy(int price)
    {

        if (money < price) return false;

        money -= price;

        return true;

    }

}
