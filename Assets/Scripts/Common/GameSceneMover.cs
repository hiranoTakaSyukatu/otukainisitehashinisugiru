using Reality.PlayerMove;
using Reality.SceneAssetManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common
{
    namespace Model
    {
        public class GameSceneMover
        {
            private int stageNum;

            public void SceneMove(int stageNum)
            {
                this.stageNum = stageNum;
                SceneManager.sceneLoaded += OnSceneLoaded;
                SceneManager.LoadScene("GameScene");
            }

            void OnSceneLoaded(Scene scene, LoadSceneMode mode)
            {
                foreach (var item in scene.GetRootGameObjects())
                {
                    if (item.name == "EventLoadAndPlay")
                    {
                        item.GetComponent<LoadStarter>().SetStageName(stageNum);
                        item.GetComponent<StageInstantiateStarter>().SetStageNum(stageNum);
                    }
                }
            }

        }
    }
}

