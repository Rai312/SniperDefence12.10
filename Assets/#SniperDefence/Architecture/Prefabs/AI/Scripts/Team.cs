using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Team : MonoBehaviour
{
    [SerializeField] private List<Unit> _units;
    [SerializeField] private TeamContainer _teamContainer;

    public TeamContainer TeamContainer => _teamContainer;
    public IReadOnlyList<Unit> Units => _units;
    public bool IsAlive { get; private set; } = true;

    public event Action Died;
    
    public void AddSpawned(DefenderSquad defenderSquat, TeamContainer teamContainer)
    {
        var defenders = defenderSquat.GetComponentsInChildren<Defender>();
        defenderSquat.transform.parent = teamContainer.transform;

        for (int i = 0; i < defenders.Length; i++)
        {
            _units.Add(defenders[i]);
        }
    }

    public void RemoveDefendersMerge(DefenderSquad[] defenderSquads)
    {
        if (this is TeamDefender)
        {
            for (int i = 0; i < defenderSquads.Length; i++)
            {
                var defenders = defenderSquads[i].GetComponentsInChildren<Defender>();
                for (int j = 0; j < defenders.Length; j++)
                {
                    defenders[j].gameObject.SetActive(false);
                    _units.Remove(defenders[j]);
                }
            }
        }
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public bool CheckLose()
    {
        foreach (var unit in _units)
        {
            if (unit.IsAlive)
                return false;
        }
        return true;
    }
}