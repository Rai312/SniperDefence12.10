public class PlayState : IGameState
{
    private readonly UI _uI;
    private readonly PlaceHolder _placeHolder;
    private readonly Battle _battle;
    private readonly Bank _bank;

    public PlayState(UI uI, PlaceHolder placeHolder, Battle battle, Bank bank)
    {
        _uI = uI;
        _placeHolder = placeHolder;
        _battle = battle;
        _bank = bank;
    }

    public void Enter()
    {
        _placeHolder.gameObject.SetActive(true);
        _placeHolder.Enable();
        _uI.PlayMenu.Show();

        _placeHolder.Spawned += OnSpawned;
        _placeHolder.Merged += OnMerged;
    }

    public void Exit()
    {
        _uI.PlayMenu.Hide();
        _placeHolder.Spawned -= OnSpawned;
        _placeHolder.Merged -= OnMerged;

        _placeHolder.gameObject.SetActive(false);
        _placeHolder.Disable();

        _battle.InitializeDefenders();
        _battle.TeamDefender.DragAndDropSystem.gameObject.SetActive(false);
        _battle.WavesManager.CurrentWave.Enable();
    }

    private void OnSpawned(DefenderSquad defenderSquad)
    {
        var defenders = defenderSquad.GetComponentsInChildren<Defender>();

        for (int i = 0; i < defenders.Length; i++)
        {
            defenders[i].Initialize(_battle.WavesManager.CurrentWave.Units);
        }

        _battle.TeamDefender.AddSpawned(defenderSquad, _battle.TeamDefender.TeamContainer);
    }

    private void OnMerged(DefenderSquad defenderSquad1, DefenderSquad defenderSquad2, DefenderSquad defenderSquad3)
    {
        OnSpawned(defenderSquad1);
        DefenderSquad[] defenders = { defenderSquad2, defenderSquad3 };
        _battle.TeamDefender.RemoveDefendersMerge(defenders);
    }
}