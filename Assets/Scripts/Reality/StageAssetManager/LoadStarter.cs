using Connector.StageAssetManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Reality
{
    namespace SceneAssetManager
    {
        /* Asset�̃��[�h�̊J�n��m�点��N���X
         * �Ή�����stageNum���O�̃V�[������Z�b�g�����
         */
        public class LoadStarter : MonoBehaviour
        {
            [Inject]
            private IAssetInfoGettable _assetInfoGettable;
            [Inject]
            private ILoadTimeReceivable _loadTimeReceivable;

            [SerializeField]
            private int _stageNum;

            void Start()
            {
                _stageNum = Mathf.Min(_stageNum, _assetInfoGettable.GetPlayableStageNum());
                if (_stageNum == 0) return;
                _loadTimeReceivable.StartLoad(_stageNum);
            }

            public void SetStageName(int stageNum)
            {
                _stageNum = stageNum; 
            }

            public int GetNowStageNum()
            {
                return _stageNum;
            }
        }
    }
}


