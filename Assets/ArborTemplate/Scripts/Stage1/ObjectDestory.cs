using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class ObjectDestory : StateBehaviour {
    
    // GameObjectを消滅させる処理

    [Header("GameObjectを消滅させる")]

    [SerializeField] private StateLink link;
    [SerializeField, Tooltip("DestoryさせるObjectのバインダーKey")] private string _objName;

    private GameObject _destoryObj;

	// Use this for initialization
	void Start () {

    }

    // Use this for awake state
    public override void OnStateAwake() {
	}

	// Use this for enter state
	public override void OnStateBegin() {
	}

	// Use this for exit state
	public override void OnStateEnd() {
	}
	
	// OnStateUpdate is called once per frame
	public override void OnStateUpdate() {
        DestoyObj();
    }

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}


    // Objectを消滅させる
    private void DestoyObj()
    {
        if (_destoryObj == null)
        {
            _destoryObj = ArborObjectContainer.GetObject(_objName);

            Destroy(_destoryObj);
            Transition(link);
        }

    }
}
