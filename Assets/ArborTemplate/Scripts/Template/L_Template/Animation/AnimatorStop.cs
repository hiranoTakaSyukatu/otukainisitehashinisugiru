using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class AnimatorStop : StateBehaviour {

    // Animationを止める処理

    [Header("Animationを止める")]

	[SerializeField] private StateLink link;
	Animator[] animators;
	// Use this for initialization
	void Start () {
		animators = FindObjectsOfType<Animator>();
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
		if (animators != null)
        {
			foreach (var item in animators)
			{
				item.enabled = false;
			}
			Transition(link);
		}
	}

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
