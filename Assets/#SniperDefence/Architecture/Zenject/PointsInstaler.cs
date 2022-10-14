using UnityEngine;
using Zenject;

public class PointsInstaler : MonoInstaller
{
    //[SerializeField] private FinishPoint _firstPoint;
    //[SerializeField] private FinishPoint _secondPoint;
    //[SerializeField] private FinishPoint _thirdPoint;
    [SerializeField] private ContainerFinishPoints _containerFinishPoints;
    [SerializeField] private ContainerFinsihPointsDefender _containerFinsihPointsDefender;

    public override void InstallBindings()
    {
        Container.Bind<ContainerFinishPoints>().FromInstance(_containerFinishPoints).AsSingle().NonLazy();
        Container.Bind<ContainerFinsihPointsDefender>().FromInstance(_containerFinsihPointsDefender).AsSingle().NonLazy();
    }
}