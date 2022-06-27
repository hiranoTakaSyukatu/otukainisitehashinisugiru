using Connector.Player;
using Virtulity.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Connector.PlayerMove;
using Virtulity.PlayerMove;
using Reality.SceneAssetManager;

namespace Reality
{
    namespace PlayerMove
    {
        /* Player�̓����v�Z�N���X�̕ϐ��̏�����
         * 
         * �v���t�@�N�^�����O
         * virtuality�̕ϐ����\�Ȍ���Reality�Ɉڂ�
         */
        public class PlayerVirtulityInfoIniter : MonoBehaviour
        {
            [Inject]
            private IPlayerStatusInitable _playerStatusInitable;

            private bool isDo = false;
            private void Update()
            {
                if (isDo) return;
                var tmp = GameObject.Find("PlayerPos")?.transform;
                Debug.Log(tmp);
                if (!tmp) return;
                gameObject.transform.position = tmp.position;
                isDo = true;
                _playerStatusInitable.PositionInit(transform.position);
                _playerStatusInitable.StateInit();
                _playerStatusInitable.WalkTypeInit(PlayerWalkDirType.RIGHT);
                Destroy(this);
            }
        }

    }
}
