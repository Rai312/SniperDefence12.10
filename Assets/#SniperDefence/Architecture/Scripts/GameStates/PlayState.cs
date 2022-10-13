using UnityEngine;

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
        Debug.Log("PlayState - Enter");
        _placeHolder.gameObject.SetActive(true);
        _uI.PlayMenu.Show();

        _placeHolder.Spawned += OnSpawned;
        _battle.TeamDefender.DragAndDropSystem.Merged += OnMerged;
    }

    public void Exit()
    {
        _uI.PlayMenu.Hide();
        //Debug.Log("PlayState - Exit");
        _placeHolder.Spawned -= OnSpawned;
        _battle.TeamDefender.DragAndDropSystem.Merged -= OnMerged;
        _placeHolder.Disable();
        _battle.InitializeDefenders();
        _battle.TeamDefender.DragAndDropSystem.gameObject.SetActive(false);
        _placeHolder.gameObject.SetActive(false);
        //_placeHolder.Disable();
        _battle.WavesManager.CurrentWave.Enable();
        Debug.Log("PlayState - Exit");
    }

    private void OnSpawned(DefenderSquad defenderSquad)
    {
        //Debug.Log("OnMerged");
        var defenders = defenderSquad.GetComponentsInChildren<Defender>();

        for (int i = 0; i < defenders.Length; i++)
        {
            //defenders[i].Initialize(_battle.TeamEnemy.Units);
            defenders[i].Initialize(_battle.WavesManager.CurrentWave.Units);
        }

        _battle.TeamDefender.AddSpawned(defenderSquad, _battle.TeamDefender.TeamContainer);
    }

    private void OnMerged(DefenderSquad defenderSquad1, DefenderSquad defenderSquad2, DefenderSquad defenderSquad3)
    {
        OnSpawned(defenderSquad1);
        //Debug.Log("OnMerged");

        DefenderSquad[] defenders = { defenderSquad2, defenderSquad3 };

        _battle.TeamDefender.RemoveDefendersMerge(defenders);
    }
}