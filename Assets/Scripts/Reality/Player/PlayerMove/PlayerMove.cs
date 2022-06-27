using UnityEngine;
using Zenject;
using UniRx;
using Connector.PlayerMove;

namespace Reality
{
    namespace PlayerMove
    {
        /* �C�x���g�̔��΂��󂯎���Ĉړ�����N���X
         * 
         */
        public class PlayerMove : MonoBehaviour
        {
            [Inject]
            private IPlayerWalkInfoSender _transformSender;
            void Start()
            {
                _transformSender.GetPlayerTransformObservable()
                    .Subscribe(x => transform.position = x);
            }
        }
    }
}
