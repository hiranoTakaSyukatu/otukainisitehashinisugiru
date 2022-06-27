using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace GameSelect
{
    namespace View
    {
        public class SelectAssetPrefabLoadStarter : MonoBehaviour
        {
            private Subject<Unit> _subject = new Subject<Unit>();

            public IObservable<Unit> GetObservable() => _subject;

            void Start()
            {
                _subject.OnNext(Unit.Default);
            }
        }

    }
}
