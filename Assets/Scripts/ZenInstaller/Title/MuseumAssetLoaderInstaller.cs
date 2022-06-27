using UnityEngine;
using Zenject;

public class MuseumAssetLoaderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<MuseumAssetLoader>()
            .AsSingle();
    }
}