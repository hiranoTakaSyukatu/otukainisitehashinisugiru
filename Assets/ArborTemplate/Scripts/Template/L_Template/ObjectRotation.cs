using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using DG.Tweening;

[AddComponentMenu("")]
public class ObjectRotation : StateBehaviour {

    // 特定のオブジェクトを回転させる処理

    [Header("オブジェクトを回転させる")]

    [SerializeField] private StateLink link;
    [SerializeField] private string _objKey;
    [SerializeField] private Vector3 _rotVec;
    [SerializeField] private float _rotTime;

    private GameObject _rotationObj;

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

        if(_rotationObj == null)
        {
            _rotationObj = ArborObjectContainer.GetObject(_objKey);
            _rotationObj.transform.DORotate(_rotVec, _rotTime);

            _rotationObj = null;

            Transition(link);
        }
    }

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
