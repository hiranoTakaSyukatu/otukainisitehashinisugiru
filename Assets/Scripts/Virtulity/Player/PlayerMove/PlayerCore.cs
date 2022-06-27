using Connector.Player;
using Connector.PlayerMove;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Virtulity
{
    namespace PlayerMove
    {
        public class PlayerCore : IPlayerStateSettable
            , IPlayerTransformSettable
            , IPlayerStatusInitable
            , IPlayerWalkDirTypeSettable
        {
            private PlayerWalkType _state = PlayerWalkType.WALK;
            private PlayerWalkDirType _playerWalkDirType;
            private Vector3 _playerVec3 = Vector3.zero;
            private bool _isInitState = false;
            private bool _isInitPosition = false;
            private bool _isInitWalkType = false;

            public PlayerWalkType State
            {
                get => _state;
                private set => _state = value;
            }
            
            public Vector3 PlayerVec3
            {
                get => _playerVec3;
                private set => _playerVec3 = value;
            }

            public PlayerWalkDirType PlayerWalkDirType
            {
                get => _playerWalkDirType;
                private set => _playerWalkDirType = value;
            }


            void IPlayerStateSettable.StateChange(PlayerWalkType state)
            {
                State = state;
            }

            void IPlayerTransformSettable.TransformPositionChange(Vector3 vec3)
            {
                PlayerVec3 = vec3;
            }

            void IPlayerWalkDirTypeSettable.DirChange(PlayerWalkDirType dirType)
            {
                PlayerWalkDirType = dirType;
            }

            void IPlayerStatusInitable.StateInit()
            {
                if (_isInitState) return;
                State = PlayerWalkType.WALK;
                _isInitState = true;
            }

            void IPlayerStatusInitable.PositionInit(Vector3 vec3)
            {
                if (_isInitPosition) return;
                PlayerVec3 = vec3;
                _isInitPosition = true;
            }

            void IPlayerStatusInitable.WalkTypeInit(PlayerWalkDirType playerWalkDirType)
            {
                if (_isInitWalkType) return;
                _playerWalkDirType = playerWalkDirType;
                _isInitWalkType = true;
            }

            
        }
    }
}

