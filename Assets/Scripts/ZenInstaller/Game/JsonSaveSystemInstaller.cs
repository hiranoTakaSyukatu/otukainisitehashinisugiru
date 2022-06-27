using Server.SaveSystem;
using UnityEngine;
using Zenject;

public class JsonSaveSystemInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<JsonSaveSystem>()
            .AsSingle();
    }
}