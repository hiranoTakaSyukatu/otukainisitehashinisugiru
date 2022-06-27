using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Virtulity
{
    namespace StageAssetManager
    {
        /* Addressableのデータコンテナ
         * GetとSetの実装
         */ 
        public class AssetContainer : IStageAssetSettable
        {
            private static Dictionary<int, StageDB> _stageDBs = new Dictionary<int, StageDB>();

            public StageDB GetStageDB(int num) => _stageDBs[num];

            public bool IsVaild(int stageNum)
            {
                return _stageDBs.ContainsKey(stageNum);
            }

            void IStageAssetSettable.SetDatebase(StageDB arborStageDB)
            {
                _stageDBs[arborStageDB.stageNum] = arborStageDB;
                foreach (var item in _stageDBs)
                {
                    Debug.Log(item.Key + ":Key " + item.Value.stageNum + ":Value");
                }
            }
        }
    }
}
