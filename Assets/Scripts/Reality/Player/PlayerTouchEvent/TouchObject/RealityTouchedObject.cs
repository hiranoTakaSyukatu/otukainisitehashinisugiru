using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Reality.TouchObject;
using TouchObjectType = Signal.C_TouchObjectType.TouchObjectType;

namespace Reality
{
    namespace Player
    {
        /* イベントを持つオブジェクトクラス
         */
        public class RealityTouchedObject : MonoBehaviour, IObjectSentable
        {
            // Playerと接触するオブジェクト処理
            [SerializeField]
            private TouchObjectType _touchObjectType;

            TouchObjectType IObjectSentable.GetEnum()
            {
                return _touchObjectType;
            }
        }

    }
}
