using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Reality.TouchObject;
using TouchObjectType = Signal.C_TouchObjectType.TouchObjectType;

namespace Reality
{
    namespace Player
    {
        /* �C�x���g�����I�u�W�F�N�g�N���X
         */
        public class RealityTouchedObject : MonoBehaviour, IObjectSentable
        {
            // Player�ƐڐG����I�u�W�F�N�g����
            [SerializeField]
            private TouchObjectType _touchObjectType;

            TouchObjectType IObjectSentable.GetEnum()
            {
                return _touchObjectType;
            }
        }

    }
}
