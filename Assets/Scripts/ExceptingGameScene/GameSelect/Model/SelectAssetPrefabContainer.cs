using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace GameSelect
{
    namespace Model
    {
        public class SelectAssetPrefabContainer : ISelectAssetPrefabSettable
        {
            private static SelectAssetPrefabDate assetDate;
            
            public SelectAssetPrefabDate GetMuseumAssetDate() => assetDate;

            bool ISelectAssetPrefabSettable.IsVaild()
            {
                return assetDate != null;
            }

            void ISelectAssetPrefabSettable.SetDatebase(SelectAssetPrefabDate selectAssetPrefab)
            {
                assetDate = selectAssetPrefab;
            }
        }
    }
}
