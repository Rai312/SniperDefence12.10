public class InitialState : IGameState
{
    private readonly UI _uI;
    private readonly Battle _battle;
    private readonly PlaceHolder _placeHolder;
    private readonly Bank _bank;

    public InitialState(UI ui,Battle battle, PlaceHolder placeHolder, Bank bank)
    {
        _uI = ui;
        _battle = battle;
        _placeHolder = placeHolder;
        _bank = bank;
    }

    public void Enter()
    {
        _battle.WavesManager.Initialize();
        _uI.OpeningMenu.Show();
        _bank.AddMoney(_bank.StartBalance);
    }

    public void Exit()
    {
    }
}
