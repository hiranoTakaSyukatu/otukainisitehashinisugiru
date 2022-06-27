using Reality.TouchObject;
using System;

namespace Connector
{
    namespace SaveSystem
    {
        interface IServerInfoUploadable
        {
            IObservable<int> GetInfoUpdateObservable();
            IObservable<int> GetClearStageObservable();

            void GetUpdateResult(in ServerResultInfo serverResultInfo);
        }
    }
}