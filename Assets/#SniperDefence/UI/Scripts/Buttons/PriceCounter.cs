using TMPro;
using UnityEngine;

public class PriceCounter : MonoBehaviour
{
    [SerializeField] private BuyButton _buyButton;
    [SerializeField] private TMP_Text _tmpText;

    private void OnEnable()
    {
        _buyButton.PriceChange += DrawPrice;
        DrawPrice(_buyButton.Price);
    }

    private void OnDisable()
    {
        _buyButton.PriceChange -= DrawPrice;
    }

    private void DrawPrice(int price)
    {
        _tmpText.text = price.ToString();
    }
}
