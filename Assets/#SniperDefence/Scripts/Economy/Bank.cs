using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    private int _money = 50;

    public void AddMoney(int value)
    {
        _money += value;
    }

    public bool RemoveMoney(int value)
    {
        if (_money > value)
        {
            return true;
            _money -= value;
        }
        else
        {
            return false;
        }
    }
}
