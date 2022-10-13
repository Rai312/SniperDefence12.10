using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{

    public int Money;

    public event Action MoneyChanged;


    public void AddMoney(int value)
    {
        Money += value;
        MoneyChanged?.Invoke();
    }

    public bool RemoveMoney(int value)
    {
        if (Money > value)
        {
            return true;
            Money -= value;
        }
        else
        {
            return false;
        }
    }
}
