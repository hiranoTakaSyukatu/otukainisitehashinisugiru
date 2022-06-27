using System;
using UnityEngine;

namespace Connector
{
    namespace PlayerMove
    {
        interface IInputReceivable
        {
            void IsRunButtonStateChange(bool boolean);
            void CurrentMoveDir(Vector3 vec3);

            event Func<Vector3,float> GetObjectDistance;
        }
    }
}