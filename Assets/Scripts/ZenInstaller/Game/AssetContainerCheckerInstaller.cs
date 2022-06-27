using UnityEngine;
using Virtulity.StageAssetManager;
using Zenject;

public class AssetContainerCheckerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<AssetContainerChecker>()
            .AsSingle();
    }
}