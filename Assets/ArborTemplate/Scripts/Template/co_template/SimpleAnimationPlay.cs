using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class SimpleAnimationPlay : StateBehaviour {

    // アニメーションを再生する処理

    [Header("アニメーションを再生")]

	[SerializeField, Tooltip("再生するアニメーションのKey")] private FlexibleString _animationKey;
	[SerializeField, Tooltip("アニメーションが終わる時間")] private FlexibleFloat _waitTime;
	[SerializeField] private StateLink _link;

	private float _count = 0.0f;
	// Use this for initialization
	void Start () {
	
	}

	// Use this for awake state
	public override void OnStateAwake() {
		AnimationContainerController.I.AnimationPlay(_animationKey.value);
	}

	// Use this for enter state
	public override void OnStateBegin() {
	}

	// Use this for exit state
	public override void OnStateEnd() {
	}
	
	// OnStateUpdate is called once per frame
	public override void OnStateUpdate() {
		_count += Time.deltaTime;
		if (_waitTime.value < _count)
        {
			Transition(_link);
        }
	}

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
