using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Reality.PlayerMove;
using UniRx;
using System;

namespace ArborSystem
{
    namespace Presenter
    {
        public class InputPresenter : MonoBehaviour
        {
            [SerializeField]
            private PlayerInputProvider _input;
            private Subject<Unit> subject = new Subject<Unit>();
            public IObserver<Unit> Observer => subject;

            void Start()
            {
                subject.Subscribe(_ => _input.InputReceptionBooleanChange());
            }
        }
    }
}

