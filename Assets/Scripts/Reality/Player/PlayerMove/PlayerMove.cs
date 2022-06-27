using UnityEngine;
using Zenject;
using UniRx;
using Connector.PlayerMove;

namespace Reality
{
    namespace PlayerMove
    {
        /* イベントの発火を受け取って移動するクラス
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
