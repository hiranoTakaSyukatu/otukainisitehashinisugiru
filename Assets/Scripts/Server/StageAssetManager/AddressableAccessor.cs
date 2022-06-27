using Connector.StageAssetManager;
using Reality.SceneAssetManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;
using System.Threading;
using Zenject;
using UniRx;

namespace Server
{
    namespace StageAssetManeger
    {
        /* Addressableのロードクラス
         * 非同期で取得し完了したらイベントを発火する
         *
         */
        public class AddressableAccessor : IInitializable
        {
            [Inject]
            private IAssetLoadable _assetLoadable;
            private List<StageDB> arborStageDBs = new List<StageDB>();
            private CancellationTokenSource source = new CancellationTokenSource();

            public void Initialize()
            {
                _assetLoadable.AssetLoad()
                    .Subscribe(x =>
                    {
                        try
                        {
                            Load(x, source.Token).Forget();
                        }
                        catch
                        {
                            UnityEngine.Debug.LogError("UniTaskError");
                        }
                    });
            }

            private async UniTaskVoid Load(string lavelName,CancellationToken token)
            {
                if (_assetLoadable.IsVaildCheack()) return;
                await Addressables.LoadAssetsAsync<StageDB>(lavelName,
                   asset =>
                   {
                       arborStageDBs.Add(asset);
                   })
                    .WithCancellation(token);
                // プレハブの個数はひとつに固定
                if (arborStageDBs.Count > 1)
                {
                    UnityEngine.Debug.LogError("ロードしたPrefabが複数あります" 
                        + "選択:" + arborStageDBs[0]);
                }
                _assetLoadable.AssetReceive(arborStageDBs[0]);
                UnityEngine.Debug.Log("ステージデータロード完了");
            }
        }
    }
}

