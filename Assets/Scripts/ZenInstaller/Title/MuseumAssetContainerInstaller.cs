using UnityEngine;
using Zenject;

public class MuseumAssetContainerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<MuseumAssetContainer>()
            .AsSingle();
    }
}