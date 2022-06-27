using System;
using UniRx;
using UnityEngine;
using Virtulity.PlayerMove;

namespace Connector
{
    namespace PlayerMove
    {
        public interface IPlayerWalkInfoSender
        {
            IObservable<Vector3> GetPlayerTransformObservable();
            IObservable<PlayerWalkDirType> GetPlayerWalkTypeObservable();
        }
    }
}
