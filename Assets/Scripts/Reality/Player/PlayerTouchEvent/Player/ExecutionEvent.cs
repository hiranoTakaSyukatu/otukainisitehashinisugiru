using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Connector.Player;
using System;
using UniRx;
using Zenject;
using Connector.StageAssetManager;

namespace Reality
{
    namespace Player
    {
        /* �C�x���g�̔��΂��󂯂ăC�x���g�f�[�^�x�[�X����Ή����Ă���C�x���g�̏����擾��
         * �������Ă���
         */
        public class ExecutionEvent : MonoBehaviour
        {
            // �C�x���g�����s���鏈��
            [Inject]
            private IEventNumSentable _eventNumSentable;
            // �C�x���g�f�[�^�x�[�X�C���^�[�t�F�C�X
            [Inject]
            private IAssetInfoGettable _assetInfoGettable;

            private GameObject obj;

            private void Start()
            {
                // ID���͂�
                _eventNumSentable.GetEventNumObserble()
                    .Subscribe(x =>
                   {
                       if (obj != null) obj.SetActive(false);
                       var tmpobj = _assetInfoGettable.GetArborEventObjct(x);
                       obj = Instantiate(tmpobj);
                   }).AddTo(this);

                _eventNumSentable.GetEventDestroyObserble()
                    .Subscribe(x =>
                    {
                        if (obj == null) return;
                        obj.SetActive(false);
                    }).AddTo(this);
            }
        }

    }

}

