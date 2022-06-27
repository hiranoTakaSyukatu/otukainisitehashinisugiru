using System.Collections;
using System.Collections.Generic;
using UniRx;
using System;
using UnityEngine;
using Zenject;

public class MuseumAssetPresenter : MonoBehaviour
{
    [SerializeField]
    private MuseumAssetLoadStarter _starter;
    [Inject]
    private MuseumAssetLoader _loader;

    private void Awake()
    {
        _starter.GetObservable()
            .Subscribe(_ => _loader.MuseumAssetLoad().Forget());

        _loader.GetObservable()
            .Subscribe(_ => Debug.Log("Ž€–S}ŠÓƒ[ƒhŠ®—¹"));
    }
}
