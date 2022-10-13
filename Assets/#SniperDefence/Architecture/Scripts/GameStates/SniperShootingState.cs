using UnityEngine;

public class SniperShootingState : IGameState
{
    private readonly UI _uI;
    private readonly CameraController _cameraController;
    private readonly Sniper _sniper;
    private readonly PlaceHolder _placeHolder;
    private readonly Battle _battle;
    private readonly TeamEnemy _teamEnemy;

  public SniperShootingState(UI uI, CameraController cameraController,
        Sniper sniper, PlaceHolder placeHolder, Battle battle, TeamEnemy teamEnemy)
    {
        _uI = uI;
        _cameraController = cameraController;
        _sniper = sniper;
        _placeHolder = placeHolder;
        _battle = battle;
        _teamEnemy = teamEnemy;
    }

    public void Enter()
    {
        //Debug.Log("ShootingState - Enter");
        //_battle.WavesManager.InitializeWave();
        //_battle.WavesManager.CurrentWave.Enable();
        _battle.InitializeEnemies();


        for (int i = 0; i < _battle.WavesManager.CurrentWave.Units.Count; i++)
        //for (int i = 0; i < _teamEnemy.Units.Count; i++)
        {
            //Debug.Log(_battle.WavesManager.CurrentWave.Units[i]);
            //Debug.Log(_battle.WavesManager.CurrentWave);
            _battle.WavesManager.CurrentWave.Units[i].SetWaiting();
            //_teamEnemy.Units[i].SetWaiting();
        }

        for (int i = 0; i < _battle.TeamDefender.Units.Count; i++)
        {
            _battle.TeamDefender.Units[i].SetWaiting();
        }

        _cameraController.PlayableDirectorFinished += Enable;

        _placeHolder.enabled = false;
        _uI.SniperMenu.Show();

        _cameraController.ActivateShowSniperRoutine();
    }

    public void Exit()
    {
        _uI.SniperMenu.Hide();
        _cameraController.PlayableDirectorFinished -= Enable;
    }

    private void Enable()
    {
        _cameraController.CameraRotator.enabled = true;
        _uI.SniperMenu.OpticalSight.enabled = true;
    }
}