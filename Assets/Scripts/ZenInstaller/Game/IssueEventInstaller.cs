using UnityEngine;
using Virtulity.Player;
using Zenject;

public class IssueEventInstaller : MonoInstaller
{
    // Zenject�̓�(�܂�����܂��悭�킩���ĂȂ�)

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<EventChanger>()
            .AsSingle();
    }
}