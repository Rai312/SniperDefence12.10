using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlaceHolder : MonoBehaviour
{
    [SerializeField] private List<Grid> _grids = new List<Grid>();
    [SerializeField] private BuyButton[] _buyButtons;
    //[SerializeField] private CheckPoint _checkPoint;
    [SerializeField] private List<CheckPoint> _checkPoints;

    private DiContainer _diContainer;
    //private List<CheckPoint> _

    public event Action<DefenderSquad> Spawned;

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

    public void Initialize()
    {
        
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
        //transform.position = _checkPoints.transform.position;
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