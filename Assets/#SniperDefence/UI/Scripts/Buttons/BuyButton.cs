using System;
using UnityEngine;

public abstract class BuyButton : MonoBehaviour
{
  // [field: SerializeField] public Defender DefenderPrefab { get; private set; }
  [field: SerializeField] public DefenderSquad DefenderSquad { get; private set; }
  [SerializeField] private int _price;
  [SerializeField] private float _recalculate;
  [SerializeField] private Bank _bank;

  public event Action<DefenderSquad> ButtonClick;

  protected virtual void OnButtonClick()
  {
      if (_bank.RemoveMoney(_price))
      {
          ButtonClick?.Invoke(DefenderSquad);
          _price = Convert.ToInt32(Math.Round(_price * _recalculate));
      }
  }
}