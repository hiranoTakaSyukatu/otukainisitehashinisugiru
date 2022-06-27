using UnityEngine;
using Virtulity.PlayerMove;

namespace Connector
{
    namespace PlayerMove
    {
        interface IPlayerStatusInitable
        {
            void StateInit();
            void PositionInit(Vector3 vec3);
            void WalkTypeInit(PlayerWalkDirType playerWalkDirType);
        }
    }
}
