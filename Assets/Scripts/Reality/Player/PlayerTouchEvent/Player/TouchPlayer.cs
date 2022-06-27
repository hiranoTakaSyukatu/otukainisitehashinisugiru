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
        /* �v���C���[�ɐڐG�����C�x���g�C���^�[�t�F�C�X�����I�u�W�F�N�g����Enum���擾��
         * �C�x���g�𔭉΂����郍�W�b�N�N���X�̃��\�b�h���R�[������
         */
        public class TouchPlayer : MonoBehaviour
        {
            [Inject]
            private IObjectRecevetable objectRecevetable;

            private void OnTriggerEnter2D(Collider2D collision)
            {
                // �C���^�[�t�F�[�X�Ăяo��

                var _touchObj = collision.gameObject.GetComponent<IObjectSentable>();


                // �ڐG���Ă���I�u�W�F�N�g�ɃC���^-�t�F�[�X������Ύ��s
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
