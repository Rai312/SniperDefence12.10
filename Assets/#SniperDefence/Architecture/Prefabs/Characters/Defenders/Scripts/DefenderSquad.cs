using UnityEngine;
using Zenject;

public class DefenderSquad : MonoBehaviour
{
    //[field: SerializeField] public ContainerFinsihPointsDefender _containerFinsihPointsDefender { get; private set; }
    [field: SerializeField] public DefenderType Type { get; private set; }
    [field: SerializeField] public int Level { get; private set; }

    //[Inject]
    //private void Construct(ContainerFinsihPointsDefender containerFinsihPointsDefender)
    //{
    //    _containerFinsihPointsDefender = containerFinsihPointsDefender;
    //}

    private int _recalculate = 2; 

    public int Price { get; private set; } = 25;
    

    private Defender[] _defenders;

    private void Awake()
    {
        _defenders = GetComponentsInChildren<Defender>();
    }

    public void IncreasePrice()
    {
        Price *= _recalculate;
        //_recalculate
    }

    public void DeactivateNavMesh()
    {
        for (int i = 0; i < _defenders.Length; i++)
        {
            _defenders[i].DeactivateNavMeshAgent();
        }
    }

    public void ActivateNavMesh()
    {
        for (int i = 0; i < _defenders.Length; i++)
        {
            _defenders[i].ActivateNavMeshAgent();
        }
    }
}