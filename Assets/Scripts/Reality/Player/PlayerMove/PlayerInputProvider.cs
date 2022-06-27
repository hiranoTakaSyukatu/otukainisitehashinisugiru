using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Connector.PlayerMove;

namespace Reality
{
    namespace PlayerMove
    {
        /* Inputクラス
         * 情報を計算クラスに渡す
         */
        public class PlayerInputProvider : MonoBehaviour
        {
            [Inject]
            private IInputReceivable _receivable;
            // イベント中は動けなくなる
            private bool isReceptionStop = true;
            private RaycastHit2D _hit;
            private int layerMask = 1 << 6;
            [SerializeField]
            private float _offset;
            private const float RAY_DISTANCE = 0.4f; 

            private void Start()
            {
                _receivable.GetObjectDistance += x => RayCul(x);
            }

            void Update()
            {
                if (!isReceptionStop) return;
                RunInput();
                DirInput();
            }

            private void RunInput()
            {

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    _receivable.IsRunButtonStateChange(true);
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    _receivable.IsRunButtonStateChange(false);
                }
            }

            private void DirInput()
            {
                Vector3 vec3 = Vector3.zero;
                vec3.y = Input.GetAxisRaw("Vertical");
                vec3.x = Input.GetAxisRaw("Horizontal");
                _receivable.CurrentMoveDir(vec3);
            }

            public void InputReceptionBooleanChange()
            {
                isReceptionStop = !isReceptionStop;
            }

            private float RayCul(Vector3 vector3)
            {
                _hit = Physics2D.Raycast(transform.position + (Vector3.up * _offset), vector3, RAY_DISTANCE, layerMask);
                return _hit.collider != null ? _hit.distance : float.MaxValue;
            }
        }
    }

}