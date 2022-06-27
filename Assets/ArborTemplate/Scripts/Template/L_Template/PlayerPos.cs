using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class PlayerPos : StateBehaviour {

    // 特定のオブジェクトをプレイヤーの位置に変更する処理

    [SerializeField] private StateLink link;

    [SerializeField] private string _objName;

    private Transform _playerPos;
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
        if(_playerPos == null)
        {
            _playerPos = ArborObjectContainer.GetObject("PlayerObj").GetComponent<Transform>();
            _obj = ArborObjectContainer.GetObject(_objName);

            _obj.transform.position = _playerPos.position;
            Transition(link);

        }
    }

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
