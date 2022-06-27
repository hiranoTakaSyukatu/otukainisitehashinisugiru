using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace GameSelect
{
    namespace Model
    {
        public class SelectAssetPrefabLoader
        {
            [Inject]
            private ISelectAssetPrefabSettable _selectAssetPrefab;

            private Subject<Unit> _subject = new Subject<Unit>();

            public IObservable<Unit> GetObservable() => _subject;

            public async UniTaskVoid SelectAssetLoad()
            {
                if (_selectAssetPrefab.IsVaild()) return;
                var tmp = await Addressables.LoadAssetAsync<SelectAssetPrefabDate>("SelectPrefab");
                _selectAssetPrefab.SetDatebase(tmp);
                
                _subject.OnNext(Unit.Default);
                _subject.OnCompleted();
            }
        }
    }
}
