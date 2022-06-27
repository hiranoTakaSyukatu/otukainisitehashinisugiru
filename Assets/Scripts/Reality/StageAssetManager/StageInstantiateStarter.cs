using Connector.StageAssetManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Reality
{
    namespace SceneAssetManager
    {
        public class StageInstantiateStarter : MonoBehaviour
        {
            [Inject]
            private IAssetInfoGettable _assetInfoGettable;
            [SerializeField]
            private SingleLayerSplit _split;
            [SerializeField]
            LoadStarter _loadStarter;

            private List<GameObject> ChildObjects = new List<GameObject>();

            [SerializeField]
            private int _stageNum;
            private void Update()
            {
                _stageNum = Mathf.Min(_stageNum, _assetInfoGettable.GetPlayableStageNum());
                if (_assetInfoGettable.GetAllFieldObjects(_stageNum) == null) return;
                if (_stageNum == 0) return;
                var tmp = Instantiate(_assetInfoGettable.GetAllFieldObjects(_stageNum));
                GetChildren(tmp, ref ChildObjects);
                _split.SetGameObject(ChildObjects.ToArray());
                Destroy(this);
            }

            public void SetStageNum(int stageNum)
            {
                _stageNum = stageNum;
            }

            public void GetChildren(GameObject obj, ref List<GameObject> allChildren)
            {
                Transform children = obj.GetComponentInChildren<Transform>();
                //éqóvëfÇ™Ç¢Ç»ÇØÇÍÇŒèIóπ
                if (children.childCount == 0)
                {
                    return;
                }
                foreach (Transform ob in children)
                {
                    allChildren.Add(ob.gameObject);
                    GetChildren(ob.gameObject, ref allChildren);
                }
            }
        }
    }
}

