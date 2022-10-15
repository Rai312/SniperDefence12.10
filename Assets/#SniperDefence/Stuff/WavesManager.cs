using System;
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

    public void ChangeWave()
    {
        _currentWave = _waves[1];
    }
}
