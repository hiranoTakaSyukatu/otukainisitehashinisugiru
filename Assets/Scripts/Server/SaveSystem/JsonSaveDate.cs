using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Server
{
    namespace SaveSystem
    {
        [System.Serializable]
        public struct JsonSaveDate
        {
            public int[] enumValues;
            public bool[] isNewUpdates;
            public int clearStageNum;
        }
    }
}

