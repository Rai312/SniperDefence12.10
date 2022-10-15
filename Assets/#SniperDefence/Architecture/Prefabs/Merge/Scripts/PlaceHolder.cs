using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlaceHolder : MonoBehaviour
{
    [SerializeField] private List<Grid> _grids = new List<Grid>();
    [SerializeField] private BuyButton[] _buyButtons;
    [SerializeField] private CheckPoint _checkPoint;

    private DiContainer _diContainer;

    public event Action<DefenderSquad> Spawned;

    [Inject]
    private void Constructor(DiContainer diContainer, CheckPoint checkPoint)
    {
        _diContainer = diContainer;
        _checkPoint = checkPoint;
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

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }

    public void ChangePosition()
    {
        transform.position = _checkPoint.transform.position;
    }

    private void SpawnDefender(DefenderSquad defenderSquad)
    {
        int count = 0;

        for (int i = 0; i < _grids.Count; i++)
        {
            if (_grids[i].IsBusy == false)
            {
                DefenderSquad newDefenderSquad = _diContainer.InstantiatePrefabForComponent<DefenderSquad>(defenderSquad, _grids[i].transform.position, Quaternion.identity, null);
                //DefenderSquad newDefenderSquad = Instantiate(defenderSquad, _grids[i].transform.position, Quaternion.identity, null);
                //Debug.Log("SpawnDefender");
                Spawned?.Invoke(newDefenderSquad);
                _grids[i].AddDefenderSquad(newDefenderSquad);
                _grids[i].MakeIsBusy();
                count++;
            }

            if (count == 1)
                break;
        }
    }
}