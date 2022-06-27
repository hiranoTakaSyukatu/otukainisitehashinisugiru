using System.Collections;
using System.Collections.Generic;
using UniRx;
using System;
using UnityEngine;

public class MuseumAssetLoadStarter : MonoBehaviour
{
    private Subject<Unit> _subject = new Subject<Unit>();

    public IObservable<Unit> GetObservable() => _subject;

    void Start()
    {
        _subject.OnNext(Unit.Default);
    }
}
