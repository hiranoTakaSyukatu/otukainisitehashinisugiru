using System;
using System.Collections.Generic;
using UniRx;

namespace Connector
{
    namespace StageAssetManager
    {
        interface IAssetLoadable
        {
            IObservable<string> AssetLoad();

            void AssetReceive(StageDB stageDB);

            bool IsVaildCheack();
        }
    }
}