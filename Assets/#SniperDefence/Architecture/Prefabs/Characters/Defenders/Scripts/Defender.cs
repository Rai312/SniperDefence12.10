﻿using UnityEngine.AI;
using Zenject;
using UnityEngine;

public class Defender : Unit
{
  private NavMeshAgent _navmeshAgent;

  private void Awake()
  {
        SetFinishTarget();
        _navmeshAgent = GetComponent<NavMeshAgent>();
  }

  public void ActivateNavMeshAgent()
  {
    _navmeshAgent.enabled = true;
  }

  public void DeactivateNavMeshAgent()
  {
    _navmeshAgent.enabled = false;
  }

    private FinishPoint[] _finishPoints;
    private FinishPoint _finishPoint;

    [SerializeField] private ContainerFinsihPointsDefender _containerFinsihPointsDefender;

    //public int Reward => _reward;

    [Inject]
    private void Construct(ContainerFinsihPointsDefender containerFinsihPointsDefender)
    {
        _containerFinsihPointsDefender = containerFinsihPointsDefender;
    }

    //private void Awake()
    //{
    //    SetFinishTarget();
    //    //_finishPoints = _containerFinishPoints.GetComponentsInChildren<FinishPoint>();
    //    //int randomIndex = Random.Range(0, _finishPoints.Length);
    //    ////Debug.Log(randomIndex);
    //    //_finishPoint = _finishPoints[randomIndex];
    //}

    public void SetFinishTarget()
    {
        _finishPoints = _containerFinsihPointsDefender.GetComponentsInChildren<FinishPoint>();
        int randomIndex = Random.Range(0, _finishPoints.Length);
        //Debug.Log(randomIndex);
        _finishPoint = _finishPoints[randomIndex];
    }

    public void MoveToFinish()
    {
        NavMeshAgent.SetDestination(_finishPoint.transform.position);
    }
}