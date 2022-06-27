using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class PlayerAnimationPlay : StateBehaviour {

    // Playerのアニメーションを再生する処理

    [SerializeField] private StateLink link;

    [SerializeField] private string _animName;

    private GameObject _player;
    private Animator _animator;

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
        if(_player == null)
        {
            _player = ArborObjectContainer.GetObject("PlayerObj");
            _animator = _player.GetComponent<Animator>();
            _animator.Play(_animName);
            Transition(link);
        }
    }

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
