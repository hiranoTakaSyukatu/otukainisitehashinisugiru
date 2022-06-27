using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class AniamtionChange : StateBehaviour {

    // アニメーションを変更する処理


    [SerializeField] private StateLink link;

    [SerializeField] private string _objName;

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

        if(_animator == null)
        {
            _animator = ArborObjectContainer.GetObject(_objName).GetComponent<Animator>();
            _animator.SetTrigger("Attack");
            Transition(link);
        }
    }

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
