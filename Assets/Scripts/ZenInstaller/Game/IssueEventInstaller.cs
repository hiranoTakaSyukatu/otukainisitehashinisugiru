using UnityEngine;
using Virtulity.Player;
using Zenject;

public class IssueEventInstaller : MonoInstaller
{
    // Zenject‚Ì“ä(‚Ü‚¾‚ ‚ñ‚Ü‚µ‚æ‚­‚í‚©‚Á‚Ä‚È‚¢)

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<EventChanger>()
            .AsSingle();
    }
}