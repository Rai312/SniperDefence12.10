using UnityEngine;
using Zenject;

public class PointsInstaller : MonoInstaller
{
    //[SerializeField] private ContainerFinishPoints _containerFinishPoints;
    [SerializeField] private FinishPointsDefender _finishPointsDefender;
    [SerializeField] private CheckPoint _checkPoint;

    public override void InstallBindings()
    {
        //Container.Bind<ContainerFinishPoints>().FromInstance(_containerFinishPoints).AsSingle().NonLazy();
        Container.Bind<FinishPointsDefender>().FromInstance(_finishPointsDefender).AsSingle().NonLazy();
        Container.Bind<CheckPoint>().FromInstance(_checkPoint).AsSingle().NonLazy();
    }
}