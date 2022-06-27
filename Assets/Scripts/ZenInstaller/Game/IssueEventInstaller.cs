using UnityEngine;
using Virtulity.Player;
using Zenject;

public class IssueEventInstaller : MonoInstaller
{
    // Zenjectの謎(まだあんましよくわかってない)

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<EventChanger>()
            .AsSingle();
    }
}