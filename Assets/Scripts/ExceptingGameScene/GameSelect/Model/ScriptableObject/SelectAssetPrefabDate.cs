using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSelect
{
    namespace Model
    {
        [CreateAssetMenu(menuName = "AddressableDate/SelectAssetPrefabDate")]
        public class SelectAssetPrefabDate : ScriptableObject
        {
            public GameObject[] selectObjects;
            public readonly static int StageNum = 2;
        }
    }
}

