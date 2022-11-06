public class SniperShootingState : IGameState
{
    private readonly UI _uI;
    private readonly CameraController _cameraController;
    private readonly Sniper _sniper;
    private readonly PlaceHolder _placeHolder;
    private readonly Battle _battle;
    private readonly TeamEnemy _teamEnemy;
    private readonly Bank _bank;

    public SniperShootingState(UI uI, CameraController cameraController,
            Sniper sniper, PlaceHolder placeHolder, Battle battle, TeamEnemy teamEnemy, Bank bank)
    {
        _uI = uI;
        _cameraController = cameraController;
        _sniper = sniper;
        _placeHolder = placeHolder;
        _battle = battle;
        _teamEnemy = teamEnemy;
        _bank = bank;
    }

    public void Enter()
    {
        _battle.InitializeEnemies();
        _battle.DefenderWon += _placeHolder.SetPositionDefenderSquads;
        
        for (int i = 0; i < _battle.WavesManager.CurrentWave.Units.Count; i++)
        {
            _battle.WavesManager.CurrentWave.Units[i].Died += OnDied;
            _battle.WavesManager.CurrentWave.Units[i].SetWaiting();
        }

        for (int i = 0; i < _battle.TeamDefender.Units.Count; i++)
        {
            _battle.TeamDefender.Units[i].SetWaiting();
        }

        _cameraController.PlayableDirectorFinished += Enable;
        _uI.SniperMenu.Show();
        _cameraController.ActivateShowSniperRoutine();
        _cameraController.CameraMove.PlayAnimation();
    }

    private void OnDied()
    {
        _bank.AddMoney(5);
    }

    public void Exit()
    {
        _uI.SniperMenu.Hide();
        _cameraController.PlayableDirectorFinished -= Enable;

        for (int i = 0; i < _battle.WavesManager.CurrentWave.Units.Count; i++)
            _battle.WavesManager.CurrentWave.Units[i].Died -= OnDied;

        _placeHolder.ChangePosition(_battle.WavesManager.CurrentWaveIndex);
        _battle.DefenderWon -= _placeHolder.SetPositionDefenderSquads;
    }

    private void Enable()
    {
        _cameraController.CameraMove.Activate();
        _cameraController.CameraRotator.enabled = true;
        _uI.SniperMenu.OpticalSight.enabled = true;
    }
}