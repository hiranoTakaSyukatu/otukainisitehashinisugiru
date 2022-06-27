using Connector.StageAssetManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Virtulity.EventDataManager;
using Zenject;

namespace Virtulity
{
    namespace StageAssetManager
    {
        /* Addressableでロードした情報のContainerをコンポジットし
         * 適切なイベントのデータを渡すクラス
         */
        public class AssetContainerChecker : IAssetInfoGettable
        {
            [Inject]
            private AssetContainer _container;

            GameObject IAssetInfoGettable.GetAllFieldObjects(int num)
            {
                if (!_container.IsVaild(num)) return null;
                return _container.GetStageDB(num).fieldObject;
            }

            GameObject IAssetInfoGettable.GetArborEventObjct(in EventDataBaseInfo eventDataBaseInfo)
            {
                var db = _container.GetStageDB(eventDataBaseInfo.stageNum);
                if (eventDataBaseInfo.stageNum != db.stageNum) return null;
                switch (eventDataBaseInfo.datebaseType)
                {
                    case DatabaseType.DEAD:
                        return db.deadEvent[eventDataBaseInfo.gimmickNum - 1];
                    case DatabaseType.CONVERSATION:
                        return db.conversionEvent[eventDataBaseInfo.gimmickNum - 1];
                    case DatabaseType.OTHER:
                        return db.otherEvent[eventDataBaseInfo.gimmickNum - 1];
                    case DatabaseType.NULL:
                        return null;
                    default:
                        return null;
                }
            }

            int IAssetInfoGettable.GetPlayableStageNum()
            {
                return StageDB.MaxStageNum;
            }
        }
    }
}

