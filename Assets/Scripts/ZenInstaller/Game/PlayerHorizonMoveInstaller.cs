using Connector.Player;
using UnityEngine;
using Virtulity.Player;
using Virtulity.PlayerMove;
using Zenject;

public class PlayerHorizonMoveInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerHorizonMove>()
            .AsSingle();
    }
}