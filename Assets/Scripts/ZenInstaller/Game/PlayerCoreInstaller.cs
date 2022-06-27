using UnityEngine;
using Virtulity.PlayerMove;
using Zenject;

namespace MyInstaller
{
    public class PlayerCoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerCore>()
                .AsSingle();
        }
    }
}
