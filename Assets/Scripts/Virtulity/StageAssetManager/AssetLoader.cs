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
        /* addressableを操作するサーバー側にメソッドをコールする
         * Addressableへ接続するクラスはここのみ
         * 
         * 要リファクタリング
         * addressableへの接続を狭めたことでほかのシーンからの接続が難しい
         * static領域を使って汎用的なラップクラスを作成する
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

            // 結果のコールバックが来たらデータをコンテナにセットする
            void IAssetLoadable.AssetReceive(StageDB stageDB)
            {
                _stageAssetSettable.SetDatebase(stageDB);
            }

            bool IAssetLoadable.IsVaildCheack()
            {
                return _stageAssetSettable.IsVaild(_stageNum);
            }

            // ロード開始のコールをする
            void ILoadTimeReceivable.StartLoad(int stageNum)
            {
                _loadSubject.OnNext("Stage" + (stageNum).ToString());
                _stageNum = stageNum;
            }
        }
    }
}
