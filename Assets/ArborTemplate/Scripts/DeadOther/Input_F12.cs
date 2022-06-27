using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Connector.Player;
using TouchObjectType = Signal.C_TouchObjectType.TouchObjectType;
using Reality.Player;
using Signal.Expansion;


[AddComponentMenu("")]
public class Input_F12 : StateBehaviour {

    // F12キーが押された時にイベントを実行する処理

    [SerializeField] private StateLink link;

    [SerializeField] private TouchObjectType _enum;

    private IObjectRecevetable objectRecevetable;

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
        if (Input.GetKeyDown(KeyCode.F12))
        {
            objectRecevetable ??= objectRecevetable.Injection();
            objectRecevetable.ObjectRecevetable(_enum);
            Transition(link);
        }
    }

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
