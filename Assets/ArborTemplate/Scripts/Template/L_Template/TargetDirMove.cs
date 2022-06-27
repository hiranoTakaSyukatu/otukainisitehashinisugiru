using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using DG.Tweening;

[AddComponentMenu("")]
public class TargetDirMove : StateBehaviour {

    // 特定のオブジェクトの位置にオブジェクトを移動させる処理

    [Header("特定のオブジェクトの位置にオブジェクトを移動させる")]

    [SerializeField] private StateLink link;

    [SerializeField] private string _targetKey;
    [SerializeField] private string _moveObjKey;
    [SerializeField] private float  _moveTime;

    private GameObject _playre;
    private GameObject _moveObj;

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
        Move();
    }

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}

    private void Move()
    {
        if (_moveObj == null || _playre == null)
        {
            _playre    = ArborObjectContainer.GetObject(_targetKey);
            _moveObj   = ArborObjectContainer.GetObject(_moveObjKey);

            _moveObj.transform.DOMove(_playre.transform.position, _moveTime).SetEase(Ease.InOutQuart);

            _moveObj = null;
            _playre  = null;

            Transition(link);
        }
    }
}
