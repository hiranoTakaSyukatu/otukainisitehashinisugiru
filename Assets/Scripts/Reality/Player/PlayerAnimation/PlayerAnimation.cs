using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using Connector.PlayerMove;
using Virtulity.PlayerMove;

namespace Reality
{
    namespace PlayerMove
    {
        /* イベントの発火を受け取って移動するクラス
         * 
         */
        public class PlayerAnimation : MonoBehaviour
        {
            [Inject]
            private IPlayerWalkInfoSender _transformSender;

            private readonly int _flontStayFlg = Animator.StringToHash("FlontStayFlg");
            private readonly int _backStayFlg  = Animator.StringToHash("BackStayFlg");
            private readonly int _flontWalkFlg = Animator.StringToHash("FlontWalkFlg");
            private readonly int _backWalkFlg  = Animator.StringToHash("BackWalkFlg");

            private Animator _animator;

            // Start is called before the first frame update
            void Start()
            {
                _animator = GetComponent<Animator>();

                _transformSender.GetPlayerWalkTypeObservable()
                .Subscribe(x =>
                {
                    AnimationBoolReset();
                    switch (x)
                    {
                        case PlayerWalkDirType.UP:
                            _animator.SetBool(_backWalkFlg, true);
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                            break;
                        case PlayerWalkDirType.DOWN:
                            _animator.SetBool(_flontWalkFlg, true);
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
                            break;
                        case PlayerWalkDirType.RIGHT:
                            _animator.SetBool(_flontWalkFlg, true);
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                            break;
                        case PlayerWalkDirType.LEFT:
                            _animator.SetBool(_backWalkFlg, true);
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
                            break;
                        case PlayerWalkDirType.UP_STAY:
                            _animator.SetBool(_backStayFlg, true);
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                            break;
                        case PlayerWalkDirType.DOWN_STAY:
                            _animator.SetBool(_flontStayFlg, true);
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
                            break;
                        case PlayerWalkDirType.RIGHT_STAY:
                            _animator.SetBool(_flontStayFlg, true);
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                            break;
                        case PlayerWalkDirType.LEFT_STAY:
                            _animator.SetBool(_backStayFlg, true);
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
                            break;
                        default:
                            throw new System.NotImplementedException("例外");
                    }
                });
            }

            private void AnimationBoolReset()
            {
                _animator.SetBool(_flontStayFlg, false);
                _animator.SetBool(_backStayFlg,  false);
                _animator.SetBool(_flontWalkFlg, false);
                _animator.SetBool(_backWalkFlg,  false);
            }
        }

    }
}
