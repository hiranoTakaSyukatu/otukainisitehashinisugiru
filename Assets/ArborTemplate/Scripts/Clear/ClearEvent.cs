using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class ClearEvent : StateBehaviour {

	// Clearのイベント
	[SerializeField] private StateLink link;



	// Use this for initialization
	void Start () {
	}

	// Use this for awake state
	public override void OnStateAwake() {
		Transition(link);
	}

	// Use this for enter state
	public override void OnStateBegin() {
	}

	// Use this for exit state
	public override void OnStateEnd() {
	}
	
	// OnStateUpdate is called once per frame
	public override void OnStateUpdate() {
	}

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
