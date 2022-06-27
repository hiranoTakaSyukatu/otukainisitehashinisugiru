using GameSelect.Model;
using GameSelect.View;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class SelectAssetContainerPresenter : MonoBehaviour
{
    [Inject]
    private SelectAssetPrefabLoader _loader;

    [Inject]
    private SelectAssetPrefabContainer _container;

    [SerializeField]
    InstantiateSelectPrefabs _instantiatePrefabs;

    private void Start()
    {
        _loader.GetObservable()
            .Subscribe(x =>
           {
               _instantiatePrefabs.LoadPrefabInstantiate(_container.GetMuseumAssetDate().selectObjects);
           });
    }
}
