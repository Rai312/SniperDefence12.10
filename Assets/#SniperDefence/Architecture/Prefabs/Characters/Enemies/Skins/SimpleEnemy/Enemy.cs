using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Unit
{
    [SerializeField] private ContainerFinishPoints _containerFinishPoints;
    [SerializeField] private int _reward;

    private FinishPoint[] _finishPoints;
    private FinishPoint _finishPoint;

    public int Reward => _reward;

    private void Awake()
    {
        _finishPoints = _containerFinishPoints.GetComponentsInChildren<FinishPoint>();
        int randomIndex = Random.Range(0, _finishPoints.Length);
        //Debug.Log(randomIndex);
        _finishPoint = _finishPoints[randomIndex];
    }

    public void MoveToFinish()
    {
        NavMeshAgent.SetDestination(_finishPoint.transform.position);
    }
}
