using Server.StageAssetManeger;
using UnityEngine;
using Zenject;

public class AddressableAccessorInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
           .BindInterfacesAndSelfTo<AddressableAccessor>()
           .AsSingle();
    }
}