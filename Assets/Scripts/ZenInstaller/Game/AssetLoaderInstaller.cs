using UnityEngine;
using Virtulity.StageAssetManager;
using Zenject;

public class AssetLoaderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<AssetLoader>()
            .AsSingle();
    }
}