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
        /* Addressable�̃��[�h�N���X
         * �񓯊��Ŏ擾������������C�x���g�𔭉΂���
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
                // �v���n�u�̌��͂ЂƂɌŒ�
                if (arborStageDBs.Count > 1)
                {
                    UnityEngine.Debug.LogError("���[�h����Prefab����������܂�" 
                        + "�I��:" + arborStageDBs[0]);
                }
                _assetLoadable.AssetReceive(arborStageDBs[0]);
                UnityEngine.Debug.Log("�X�e�[�W�f�[�^���[�h����");
            }
        }
    }
}

