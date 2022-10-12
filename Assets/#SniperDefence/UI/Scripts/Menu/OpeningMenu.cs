using UnityEngine;
using UnityEngine.UI;

public class OpeningMenu : Menu
{
    [SerializeField] private Button _startButton;

    public Button StartButton => _startButton;
}
