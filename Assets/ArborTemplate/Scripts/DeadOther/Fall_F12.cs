using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using DG.Tweening;

[AddComponentMenu("")]
public class Fall_F12 : StateBehaviour {

    // F12が落ちてくる処理

    [SerializeField] private StateLink link;

    [SerializeField, Tooltip("落ちてくる時間")] private float _fallTime;
    [SerializeField, Tooltip("X軸位置調整用(落ちてくる場所)")] private float _offset_X;
    [SerializeField, Tooltip("Y軸位置調整用(落ちてくる場所)")] private float _offset_Y;

    private Transform _playerPos;
    private GameObject _f12Obj;
    private float firstObjPos_Y = 30;

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
        if (_playerPos == null)
        {
            _playerPos = ArborObjectContainer.GetObject("PlayerObj").GetComponent<Transform>();
            _f12Obj = ArborObjectContainer.GetObject("F12Obj");


            _f12Obj.transform.position = new Vector3
                                    (
                                        _playerPos.position.x,
                                        _playerPos.position.y + firstObjPos_Y,
                                        _playerPos.position.z
                                    );

            _f12Obj.transform.DOMove(new Vector3(_f12Obj.transform.position.x + _offset_X, _playerPos.position.y + _offset_Y, _f12Obj.transform.position.z), _fallTime).SetEase(Ease.InOutQuart);
            Transition(link);
        }
    }

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
