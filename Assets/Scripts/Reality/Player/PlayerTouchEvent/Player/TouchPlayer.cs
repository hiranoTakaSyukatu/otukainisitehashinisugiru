using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Connector.Player;
using Reality.TouchObject;
using Zenject;
using TouchObjectType = Signal.C_TouchObjectType.TouchObjectType;

namespace Reality
{
    namespace Player
    {
        /* プレイヤーに接触したイベントインターフェイスを持つオブジェクトからEnumを取得し
         * イベントを発火させるロジッククラスのメソッドをコールする
         */
        public class TouchPlayer : MonoBehaviour
        {
            [Inject]
            private IObjectRecevetable objectRecevetable;

            private void OnTriggerEnter2D(Collider2D collision)
            {
                // インターフェース呼び出し

                var _touchObj = collision.gameObject.GetComponent<IObjectSentable>();


                // 接触しているオブジェクトにインタ-フェースがあれば実行
                if (_touchObj != null)
                {
                    objectRecevetable.ObjectRecevetable(_touchObj.GetEnum());
                }
            }

            private void OnTriggerExit2D(Collider2D collision)
            {
                objectRecevetable.OnPlayEventRelease();
            }
        }

    }
}
