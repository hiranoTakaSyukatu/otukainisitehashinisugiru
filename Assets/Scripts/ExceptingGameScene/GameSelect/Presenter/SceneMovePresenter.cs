using GameSelect.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Common.Model;

namespace GameSelect
{
    namespace Presenter
    {
        public class SceneMovePresenter : MonoBehaviour
        {
            GameSceneMover _sceneMover = new GameSceneMover();

            [SerializeField]
            PrarentController _prarentController;

            private void Start()
            {
                _prarentController.GetObservable()
                    .Subscribe(x => _sceneMover.SceneMove(x));
            }
        }
    }
}
