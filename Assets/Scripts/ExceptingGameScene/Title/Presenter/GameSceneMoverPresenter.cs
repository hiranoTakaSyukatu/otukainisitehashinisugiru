using Common.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Title.View;

namespace Title
{
    namespace Presenter
    {
        public class GameSceneMoverPresenter : MonoBehaviour
        {
            GameSceneMover _gameSceneMover = new GameSceneMover();
            ClearDateKeeper dateKeeper = new ClearDateKeeper();
            [SerializeField]
            TitleGameSceneLoad _gameSceneLoad;
            // Start is called before the first frame update
            void Start()
            {
                _gameSceneLoad.Observable
                    .Subscribe(x => _gameSceneMover.SceneMove(dateKeeper.GetClearStageNum() + 1));
            }
        }
    }
}

