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
        /* イベントの発火を受けてイベントデータベースから対応しているイベントの情報を取得し
         * 生成している
         */
        public class ExecutionEvent : MonoBehaviour
        {
            // イベントを実行する処理
            [Inject]
            private IEventNumSentable _eventNumSentable;
            // イベントデータベースインターフェイス
            [Inject]
            private IAssetInfoGettable _assetInfoGettable;

            private GameObject obj;

            private void Start()
            {
                // IDが届く
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

