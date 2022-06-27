using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class PlayerDeadAnimation : StateBehaviour {
    // Use this for initialization

    // Player死ぬときアニメーション

    private GameObject _playerObj;

    private SpriteRenderer _playerSr;
    private Animator  _animationObj;

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

        if(_playerObj == null)
        {
            _playerObj = GameObject.Find("Player");
            _animationObj = GameObject.Find("ss").GetComponent<Animator>();
            _playerSr = _playerObj.GetComponent<SpriteRenderer>();

            _playerSr.enabled = false;
            _animationObj.Play("");
;        }
	}

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
