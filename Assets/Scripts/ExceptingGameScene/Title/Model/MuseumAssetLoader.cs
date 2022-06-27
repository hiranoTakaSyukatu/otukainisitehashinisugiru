using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Title.Model;
using UniRx;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class MuseumAssetLoader
{
    [Inject]
    private IMuseumAssetSettable _museumAssetSettable;

    private Subject<Unit> _subject = new Subject<Unit>();

    public IObservable<Unit> GetObservable() => _subject;

    public async UniTaskVoid MuseumAssetLoad()
    {
        if (_museumAssetSettable.IsVaild()) return;
        var tmp = await Addressables.LoadAssetAsync<MuseumAssetDate>("Museum");
        _museumAssetSettable.SetDatebase(tmp);
        _subject.OnNext(Unit.Default);
        _subject.OnCompleted();
    }
}
