using System;
using UnityEngine;

public abstract class BuyButton : MonoBehaviour
{
  // [field: SerializeField] public Defender DefenderPrefab { get; private set; }
  [field: SerializeField] public DefenderSquad DefenderSquad { get; private set; }
  [SerializeField] private int _price;
  [SerializeField] private int _recalculate;

  public event Action<DefenderSquad,int> ButtonClick;

  protected virtual void OnButtonClick()
  {
      ButtonClick?.Invoke(DefenderSquad,_price);
      _price = _price * _recalculate;
  }
}