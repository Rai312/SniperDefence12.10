using System;
using UnityEngine;

public class Battle : MonoBehaviour
{
    [SerializeField] private TeamDefender _teamDefender;
    [SerializeField] private WavesManager _wavesManager;

    public TeamDefender TeamDefender => _teamDefender;
    public WavesManager WavesManager => _wavesManager;

    public event Action DefenderWon;
    public event Action EnemyWon;

    private void OnDestroy()
    {
        foreach (var unit in _teamDefender.Units)
        {
            unit.Died -= CheckWinEnemy;
        }

        foreach (var unit in _wavesManager.CurrentWave.Units)
        {
            unit.Died -= CheckWinDefenders;
        }
    }

    public void InitializeDefenders()
    {
        foreach (var unit in _teamDefender.Units)
        {
            unit.Initialize(_wavesManager.CurrentWave.Units);
            unit.Died += CheckWinEnemy;
        }
    }

    public void InitializeEnemies()
    {
        foreach (var unit in _wavesManager.CurrentWave.Units)
        {

            unit.Initialize(_teamDefender.Units);
            unit.Died += CheckWinDefenders;
        }
    }

    private void CheckWinDefenders()
    {
        bool isLoserEnemyTeam = _wavesManager.CurrentWave.CheckLose();
        
        if (isLoserEnemyTeam)
        {
            DefenderWon?.Invoke();
            _wavesManager.SetNextWave();
        }
    }

    private void CheckWinEnemy()
    {
        bool isLoserEnemyTeam = _wavesManager.CurrentWave.CheckLose();
    }
}
