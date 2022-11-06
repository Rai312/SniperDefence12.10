using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlaceHolder : MonoBehaviour
{
    [SerializeField] private List<Grid> _grids = new List<Grid>();
    [SerializeField] private BuyButton[] _buyButtons;
    [SerializeField] private List<CheckPoint> _checkPoints;

    private DiContainer _diContainer;
    private List<DefenderSquad> _spawnedDefendersMap = new List<DefenderSquad>();

    public event Action<DefenderSquad> Spawned;
    public event Action<DefenderSquad, DefenderSquad, DefenderSquad> Merged;

    [Inject]
    private void Constructor(DiContainer diContainer, List<CheckPoint> checkPoint)
    {
        _diContainer = diContainer;
        _checkPoints = checkPoint;
    }

    private void OnEnable()
    {
        for (int i = 0; i < _buyButtons.Length; i++)
        {
            _buyButtons[i].ButtonClick += SpawnDefender;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _buyButtons.Length; i++)
        {
            _buyButtons[i].ButtonClick -= SpawnDefender;
        }
    }

    public void SetPositionDefenderSquads()
    {
        for (int i = 0; i < _grids.Count; i++)
        {
            if (_grids[i].DefenderSquad != null)
                _grids[i].DefenderSquad.transform.position = _grids[i].transform.position;
        }
    }

    public void Instantiate(DefenderSquad defenderSquad, Grid grid, Grid activeGrid)
    {
        DefenderSquad newDefenderSquad =
            _diContainer.InstantiatePrefabForComponent<DefenderSquad>(defenderSquad, grid.transform.position,
                Quaternion.identity, null);
        Merged?.Invoke(newDefenderSquad, grid.DefenderSquad, activeGrid.DefenderSquad);
        grid.AddDefenderSquad(newDefenderSquad);
        _spawnedDefendersMap.Add(newDefenderSquad);
    }

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }

    public void ChangePosition(int currentIndexWave)
    {
        transform.position = _checkPoints[currentIndexWave].transform.position;
    }

    private void SpawnDefender(DefenderSquad defenderSquad)
    {
        int count = 0;

        for (int i = 0; i < _grids.Count; i++)
        {
            if (_grids[i].IsBusy == false)
            {
                DefenderSquad newDefenderSquad =
                    _diContainer.InstantiatePrefabForComponent<DefenderSquad>(defenderSquad,
                        _grids[i].transform.position, Quaternion.identity, null);

                Spawned?.Invoke(newDefenderSquad);
                _grids[i].AddDefenderSquad(newDefenderSquad);
                _spawnedDefendersMap.Add(newDefenderSquad);
                _grids[i].MakeIsBusy();
                count++;
            }

            if (count == 1)
                break;
        }
    }
}