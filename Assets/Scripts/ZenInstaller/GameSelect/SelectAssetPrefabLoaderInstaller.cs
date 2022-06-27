using GameSelect.Model;
using UnityEngine;
using Zenject;

public class SelectAssetPrefabLoaderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SelectAssetPrefabLoader>()
            .AsSingle();
    }
}