using UnityEngine.AI;
using Zenject;
using UnityEngine;
using System.Collections.Generic;

public class Defender : Unit
{
    [SerializeField] private FinishPointsDefender _finishPointsDefender;

    private NavMeshAgent _navmeshAgent;
    private FinishPoint[] _finishPoints;
    private FinishPoint _finishPoint;
    private Vector3 _position;

    [Inject]
    private void Construct(FinishPointsDefender finishPointsDefender)
    {
        _finishPointsDefender = finishPointsDefender;
    }

    private void Awake()
    {
         SetFinishTarget();
        _navmeshAgent = GetComponent<NavMeshAgent>();
    }

    public override void Initialize(IReadOnlyList<Unit> enemies)
    {
        base.Initialize(enemies);

    }

    public void ActivateNavMeshAgent()
    {
        _navmeshAgent.enabled = true;
    }

    public void DeactivateNavMeshAgent()
    {
        _navmeshAgent.enabled = false;
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
        _finishPoints = _finishPointsDefender.GetComponentsInChildren<FinishPoint>();
        int randomIndex = Random.Range(0, _finishPoints.Length);
        _finishPoint = _finishPoints[randomIndex];
    }

    public void MoveToFinish()
    {
        NavMeshAgent.SetDestination(_finishPoint.transform.position);
    }
}