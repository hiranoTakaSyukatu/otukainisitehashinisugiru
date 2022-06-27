using System;
using UniRx;
using Virtulity.EventDataManager;

namespace Connector
{
    namespace Player
    {
        interface IEventNumSentable
        {
            IObservable<EventDataBaseInfo> GetEventNumObserble();

            IObservable<Unit> GetEventDestroyObserble();
        }
    }
}