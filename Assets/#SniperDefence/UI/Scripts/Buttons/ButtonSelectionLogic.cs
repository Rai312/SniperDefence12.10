using System;
using UnityEngine;
using DG.Tweening;

public class ButtonSelectionLogic : MonoBehaviour
{
  private Vector3 targetScale = new Vector3(1.1f, 1.1f, 1.1f);
  private float _durationScaling = 0.2f;
  private BuyButton[] _buyButtons;

  public event Action<Defender> ButtonSelected;

  private void Awake()
  {
    _buyButtons = GetComponentsInChildren<BuyButton>();
  }
  
  private void OnButtonClick(BuyButton buyButton)
  {
    ChangeScaleAnimation(targetScale, buyButton);
    DisableButtonSelection(buyButton);
  }

  private void DisableButtonSelection(BuyButton activeButton)
  {
    for (int i = 0; i < _buyButtons.Length; i++)
    {
      if (_buyButtons[i] != activeButton)
        ChangeScaleAnimation(Vector3.one, _buyButtons[i]);
    }
  }

  private void ChangeScaleAnimation(Vector3 targetScale, BuyButton buyButton)
  {
    buyButton.transform.DOScale(targetScale, _durationScaling);
  }
}