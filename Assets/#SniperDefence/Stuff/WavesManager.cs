using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WavesManager : MonoBehaviour
{
    [SerializeField] private List<TeamEnemy> _waves;
    [SerializeField] private TeamDefender _teamDefender;
    [SerializeField] private List<CheckPoint> _checkPoints;

    private TeamEnemy _currentWave;
    private int _startWaveIndex = 0;
    private int _currentWaveIndex;
    private int _stepIndexSwitcher = 1;

    public TeamEnemy CurrentWave => _currentWave;
    public IReadOnlyList<TeamEnemy> Waves => _waves;
    public int CurrentWaveIndex => _currentWaveIndex;

    public event Action CurrentWaveDied;

    [Inject]
    private void Construct(List<CheckPoint> checkPoints)
    {
        _checkPoints = checkPoints;
    }

    public void Initialize()
    {
        _currentWave = _waves[_startWaveIndex];
        _currentWaveIndex = _startWaveIndex;
    }

    public void SetNextWave()
    {
        if (_currentWave != null)
        {
            //_currentWave.
            _currentWave = _waves[_currentWaveIndex + _stepIndexSwitcher];
            _checkPoints[_currentWaveIndex].Set();
            _currentWaveIndex++;
        }
    }
}
