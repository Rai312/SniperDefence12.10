using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PointsInstaller : MonoInstaller
{
    //[SerializeField] private ContainerFinishPoints _containerFinishPoints;
    [SerializeField] private FinishPointsDefender _finishPointsDefender;
    [SerializeField] private List<CheckPoint> _checkPoints;

    public override void InstallBindings()
    {
        //Container.Bind<ContainerFinishPoints>().FromInstance(_containerFinishPoints).AsSingle().NonLazy();
        Container.Bind<FinishPointsDefender>().FromInstance(_finishPointsDefender).AsSingle().NonLazy();

        Container.Bind<List<CheckPoint>>().FromInstance(_checkPoints).AsSingle().NonLazy();

        //for (int i = 0; i < _checkPoints.Count; i++)
        //{
        //    Container.Bind<CheckPoint>().FromInstance(_checkPoints[i]).AsSingle().NonLazy();
        //}
    }
}