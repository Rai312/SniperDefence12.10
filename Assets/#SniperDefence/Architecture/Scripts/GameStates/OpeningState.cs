public class OpeningState : IGameState
{
    private readonly UI _uI;

    public OpeningState(UI uI)
    {
        _uI = uI;
    }

    public void Enter()
    {
        _uI.OpeningMenu.Show();
    }

    public void Exit()
    {
        _uI.OpeningMenu.Hide();
    }
}
