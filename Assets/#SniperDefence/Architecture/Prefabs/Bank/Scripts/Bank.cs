using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{

    private int _money;

    public event Action MoneyChanged;

    public int Money => _money;

    public void AddMoney(int value)
    {
        _money += value;
        MoneyChanged?.Invoke();
    }

    public bool RemoveMoney(int value)
    {
        if (_money >= value)
        {
            _money -= value;
            MoneyChanged?.Invoke();
            return true;
        }
        else
        {
            return false;
        }
    }
}
