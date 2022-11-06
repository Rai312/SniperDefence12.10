using System;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] private int _startBalance = 50;
    
    private int _money;
    
    public event Action MoneyChanged;

    public int Money => _money;
    public int StartBalance => _startBalance;

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
