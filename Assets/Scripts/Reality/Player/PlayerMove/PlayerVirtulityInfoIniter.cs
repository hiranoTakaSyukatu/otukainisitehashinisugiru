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
        /* Playerの動き計算クラスの変数の初期化
         * 
         * 要リファクタリング
         * virtualityの変数を可能な限りRealityに移す
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
