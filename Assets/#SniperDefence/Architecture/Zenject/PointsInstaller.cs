using UnityEngine;
using Zenject;

public class PointsInstaller : MonoInstaller
{
    [SerializeField] private ContainerFinishPoints _containerFinishPoints;
    [SerializeField] private ContainerFinsihPointsDefender _containerFinsihPointsDefender;

    public override void InstallBindings()
    {
        Container.Bind<ContainerFinishPoints>().FromInstance(_containerFinishPoints).AsSingle().NonLazy();
        Container.Bind<ContainerFinsihPointsDefender>().FromInstance(_containerFinsihPointsDefender).AsSingle().NonLazy();
    }
}