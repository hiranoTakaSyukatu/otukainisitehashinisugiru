using UnityEngine;
using Virtulity.SaveSystem;
using Zenject;

public class UseServerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<UseServer>()
            .AsSingle();
    }
}