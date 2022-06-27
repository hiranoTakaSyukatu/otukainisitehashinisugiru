using Common.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSelect
{
    namespace View
    {
        public class InstantiateSelectPrefabs : MonoBehaviour
        {
            ClearDateKeeper _clearDateKeeper = new ClearDateKeeper();
            [SerializeField]
            GameObject parentObj;
            private bool isFinish = false;
            private const float DISTANCE = 7.0f;

            public void LoadPrefabInstantiate(GameObject[] gameObjects)
            {
                if (gameObjects == null) return;
                if (isFinish) return;
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    var obj = Instantiate(gameObjects[i]);
                    obj.transform.position += new Vector3(DISTANCE * i, 0, 0);
                    obj.transform.parent = parentObj.transform;
                    if (i > _clearDateKeeper.GetClearStageNum())
                    {
                        obj.GetComponent<SpriteRenderer>().color = Color.black;
                    }
                }
                isFinish = true;
                //Destroy(this);
            }
        }
    }
}

