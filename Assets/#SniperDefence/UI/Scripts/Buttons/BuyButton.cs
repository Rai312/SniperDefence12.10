using System;
using UnityEngine;

public abstract class BuyButton : MonoBehaviour
{
  [field: SerializeField] public DefenderSquad DefenderSquad { get; private set; }
  [SerializeField] private int _price;
  [SerializeField] private float _recalculate;
  [SerializeField] private Bank _bank;

  public event Action<DefenderSquad> ButtonClick;
  public event Action<int> PriceChange;

  public int Price => _price;
  
  protected virtual void OnButtonClick()
  {
      if (_bank.RemoveMoney(_price))
      {
          ButtonClick?.Invoke(DefenderSquad);
          
          _price = Convert.ToInt32(Math.Round(_price * _recalculate));
          PriceChange?.Invoke(_price);
      }
  }
}