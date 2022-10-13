using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    [SerializeField] private List<TeamEnemy> _waves;
    [SerializeField] private TeamDefender _teamDefender;

    private TeamEnemy _currentWave;
    private int _startWaveIndex = 0;

    public TeamEnemy CurrentWave => _currentWave;
    public IReadOnlyList<TeamEnemy> Waves => _waves;

    public event Action CurrentWaveDied;

    public void Initialize()
    {
        _currentWave = _waves[_startWaveIndex];
    }

    //public void EnableWave()
    //{
    //    _currentWave.TeamContainer.Enable();
    //}

    //public void InitializeWave()
    //{
    //    foreach (var unit in _currentWave.Units)
    //    {
    //        unit.Initialize(_teamDefender.Units);
    //        //unit.Died += CheckWin;
    //    }

    //}

    private void CheckWin()
    {
        bool firstTeamResult = _teamDefender.CheckLose();
        bool secondTeamResult = _currentWave.CheckLose();

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
