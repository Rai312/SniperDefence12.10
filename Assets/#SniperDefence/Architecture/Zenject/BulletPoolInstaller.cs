using UnityEngine;
using Zenject;

public class BulletPoolInstaller : MonoInstaller
{
   [SerializeField] private Transform _BulletPoolConteiner;
   
   public override void InstallBindings()
   {
      Container.Bind<Transform>().FromInstance(_BulletPoolConteiner).AsSingle().NonLazy();
   }
}