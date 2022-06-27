using Connector.SaveSystem;
using Reality.TouchObject;
using Signal.Expansion;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Virtulity
{
    namespace SaveSystem
    {
        public class UseServer : IServerInfoUploadable, IUploadTimeReceivable
        {
            private Subject<int> _infoUpdateSubject = new Subject<int>();

            private Subject<int> _clearEventSubject = new Subject<int>();

            public UseServer()
            {
                InterfaceExpansion.Bind(this);
            }

            void IUploadTimeReceivable.ClearEventReceive(int stageNum)
            {
                _clearEventSubject.OnNext(stageNum);
            }

            void IUploadTimeReceivable.DeadEventReceive(int enumValue)
            {
                _infoUpdateSubject.OnNext(enumValue);
            }

            IObservable<int> IServerInfoUploadable.GetClearStageObservable()
            {
                return _clearEventSubject;
            }

            IObservable<int> IServerInfoUploadable.GetInfoUpdateObservable()
            {
                return _infoUpdateSubject;
            }

            void IServerInfoUploadable.GetUpdateResult(in ServerResultInfo serverResultInfo)
            {
                InterfaceExpansion.SetIsNewValue(this, serverResultInfo.isNewUpdate);
            }
        }
    }
}

