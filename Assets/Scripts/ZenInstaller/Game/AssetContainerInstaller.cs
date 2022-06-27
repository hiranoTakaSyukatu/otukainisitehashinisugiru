using UnityEngine;
using Virtulity.StageAssetManager;
using Zenject;

public class AssetContainerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<AssetContainer>()
            .AsSingle();
    }
}