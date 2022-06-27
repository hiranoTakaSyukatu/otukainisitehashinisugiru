using Connector.StageAssetManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

namespace Virtulity
{
    namespace StageAssetManager
    {
        /* addressable�𑀍삷��T�[�o�[���Ƀ��\�b�h���R�[������
         * Addressable�֐ڑ�����N���X�͂����̂�
         * 
         * �v���t�@�N�^�����O
         * addressable�ւ̐ڑ������߂����Ƃłق��̃V�[������̐ڑ������
         * static�̈���g���Ĕėp�I�ȃ��b�v�N���X���쐬����
         */
        public class AssetLoader : ILoadTimeReceivable, IAssetLoadable
        {
            [Inject]
            private IStageAssetSettable _stageAssetSettable;
            private Subject<string> _loadSubject = new Subject<string>();
            private int _stageNum;

            IObservable<string> IAssetLoadable.AssetLoad()
            {
                return _loadSubject;
            }

            // ���ʂ̃R�[���o�b�N��������f�[�^���R���e�i�ɃZ�b�g����
            void IAssetLoadable.AssetReceive(StageDB stageDB)
            {
                _stageAssetSettable.SetDatebase(stageDB);
            }

            bool IAssetLoadable.IsVaildCheack()
            {
                return _stageAssetSettable.IsVaild(_stageNum);
            }

            // ���[�h�J�n�̃R�[��������
            void ILoadTimeReceivable.StartLoad(int stageNum)
            {
                _loadSubject.OnNext("Stage" + (stageNum).ToString());
                _stageNum = stageNum;
            }
        }
    }
}
