using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.SceneManagement.SceneManager;
using UniRx;
using System;

namespace Title
{
    namespace View
    {
        public class TitleGameSceneLoad : MonoBehaviour, IArrowSelectorBehavior
        {
            [SerializeField]
            FadeInOut fadeInOut;
            private Subject<Unit> _subject = new Subject<Unit>();
            public IObservable<Unit> Observable { get => _subject; }
            void IArrowSelectorBehavior.EnterAction()
            {
                fadeInOut.FadeOut(1.0f, () => _subject.OnNext(Unit.Default));
                _subject.AddTo(this);
            }
        }

    }
}
