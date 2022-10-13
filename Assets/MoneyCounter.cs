using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private Bank _bank;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _bank.MoneyChanged += DrawMoney;
        
    }

    private void OnDisable()
    {
        _bank.MoneyChanged -= DrawMoney;
    }

    private void DrawMoney()
    {
        _text.text = _bank.Money.ToString();
    }
}
