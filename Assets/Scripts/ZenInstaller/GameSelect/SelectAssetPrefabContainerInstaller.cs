using GameSelect.Model;
using UnityEngine;
using Zenject;

public class SelectAssetPrefabContainerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SelectAssetPrefabContainer>()
            .AsSingle();
    }
}