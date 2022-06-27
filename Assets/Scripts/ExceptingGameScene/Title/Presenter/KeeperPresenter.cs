using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Title.Model;
using Zenject;
using Server.SaveSystem;
using Common.Model;
using Title.View;

namespace Title
{
    namespace Presenter
    {
        public class KeeperPresenter : MonoBehaviour
        {
            ClearDateKeeper dateKeeper = new ClearDateKeeper();
            [SerializeField]
            LoadGameSceneTextChanger _loadGameSceneTextChanger;

            // Start is called before the first frame update
            void Awake()
            {
                _loadGameSceneTextChanger.IsFirastCheckFunc += 
                    () => dateKeeper.GetClearStageNum() == 0;
            }
        }

    }
}
