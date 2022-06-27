using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class SpriteActiveSwitch : StateBehaviour {
    // Use this for initialization

    // スプライトのアクティブ化を変更 & 特定の位置に変更する処理

    [Header("あああああ")]

    [SerializeField] private StateLink link;

    [SerializeField] private string _objName;
    [SerializeField] private string _spriteObjName;
    [SerializeField] private bool   _activeFlg;
    [SerializeField] private float _offset_X;
    [SerializeField] private float _offset_Y;

    private GameObject _eventObj;
    private SpriteRenderer _sr;

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

        if(_sr == null)
        {
            _sr = GameObject.Find(_spriteObjName).GetComponent<SpriteRenderer>();
            _eventObj = GameObject.Find(_objName);

            _sr.transform.position = new Vector3
                                            (
                                                _eventObj.transform.position.x + _offset_X,
                                                _eventObj.transform.position.y + _offset_Y,
                                                0
                                            );


            _sr.enabled = _activeFlg;
            Transition(link);
        }
    }

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
