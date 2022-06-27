using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
using GameSelect.Model;
using GameSelect.View;

namespace GameSelect
{
    namespace Presenter
    {
        public class SelectAssetPrefabPresenter : MonoBehaviour
        {
            [SerializeField]
            SelectAssetPrefabLoadStarter _starter;

            [Inject]
            private SelectAssetPrefabLoader _loader;

            private void Awake()
            {
                _starter.GetObservable()
                    .Subscribe(_ => _loader.SelectAssetLoad().Forget())
                    .AddTo(this);
            }
        }

    }
}
