using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField] private TeamDefender _teamDefender;
    [SerializeField] private WavesManager _wavesManager;

    public TeamDefender TeamDefender => _teamDefender;
    public WavesManager WavesManager => _wavesManager;

    public event Action DefenderWon;
    public event Action EnemyWon;
    //[SerializeField] private Text _drawMessage;
    //[SerializeField] private Text _firstTeamWinText;
    //[SerializeField] private Text _secondTeamWinText;

    private void OnDestroy()
    {
        foreach (var unit in _teamDefender.Units)
        {
            unit.Died -= CheckWin;
            //unit.Died -= CheckWinEnemy;
        }

        //foreach (var unit in _teamEnemy.Units)
        //{
        //    unit.Died -= CheckWin;
        //}

        foreach (var unit in _wavesManager.CurrentWave.Units)
        {
            unit.Died -= CheckWin;
            //unit.Died -= CheckWinDefenders;
        }
    }

    public void InitializeDefenders()
    {
        foreach (var unit in _teamDefender.Units)
        {
            unit.Initialize(_wavesManager.CurrentWave.Units);
            unit.Died += CheckWin;
            //unit.Died += CheckWinEnemy;
        }
    }

    public void InitializeEnemies()
    {
        foreach (var unit in _wavesManager.CurrentWave.Units)
        {
            //for (int i = 0; i < _wavesManager.CurrentWave.Units.Count; i++)
            //{
            //    Debug.Log(_teamDefender.Units[i]);
            //}

            unit.Initialize(_teamDefender.Units);
            unit.Died += CheckWin;
            //unit.Died += CheckWinDefenders;
        }
        //_wavesManager.CurrentWave.Units[1].DebugTargets();
    }

    private void CheckWinDefenders()
    {
        bool isLoserEnemyTeam = _wavesManager.CurrentWave.CheckLose();
        if (isLoserEnemyTeam)
        {
            Debug.Log("isLoserEnemyTeam");
        }
    }

    private void CheckWinEnemy()
    {
        bool isLoserEnemyTeam = _wavesManager.CurrentWave.CheckLose();
        if (isLoserEnemyTeam)
        {
            Debug.Log("isLoserDefenderTeam");
        }
    }

    private void CheckWin()
    {
        bool isLoserDefenderTeam = _teamDefender.CheckLose();
        bool isLoserEnemyTeam = _wavesManager.CurrentWave.CheckLose();



        if (isLoserDefenderTeam && isLoserEnemyTeam)
        {
            Debug.Log("isLoserDefenderTeam");
        }
        else
        {
            if (isLoserDefenderTeam)
            {
                Debug.Log("isLoserDefenderTeam");
            }
            else if (isLoserEnemyTeam)
            {
                Debug.Log("isLoserEnemyTeam");
            }
        }

        //Debug.Log("CheckWin");
        //if (firstTeamResult && secondTeamResult)
        //{
        //    _drawMessage.gameObject.SetActive(true);
        //}
        //else
        //{
        //    if (firstTeamResult)
        //        _secondTeamWinText.gameObject.SetActive(true);
        //    if (secondTeamResult)
        //        _firstTeamWinText.gameObject.SetActive(true);
        //}
    }
}
