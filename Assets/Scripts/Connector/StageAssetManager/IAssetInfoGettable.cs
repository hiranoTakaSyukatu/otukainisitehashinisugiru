using UnityEngine;
using Virtulity.EventDataManager;

namespace Connector
{
    namespace StageAssetManager
    {
        interface IAssetInfoGettable
        {
            GameObject GetArborEventObjct(in EventDataBaseInfo eventDataBaseInfo);

            GameObject GetAllFieldObjects(int stageNum);

            int GetPlayableStageNum();
        }
    }
}