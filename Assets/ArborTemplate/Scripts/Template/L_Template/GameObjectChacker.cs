using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class GameObjectChacker : StateBehaviour {

    // 特定のGameObjectが存在するかをチェックする処理

    [SerializeField] private StateLink link1;
    [SerializeField] private StateLink link2;

    [SerializeField] private string _objName;

    private GameObject _obj;

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

        if (_obj == null)
        {
            _obj = ArborObjectContainer.GetObject(_objName);

            if (_obj == null)
            {
                Transition(link1);
            }
            else
            {
                Transition(link2);
            }
        }
	}

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
