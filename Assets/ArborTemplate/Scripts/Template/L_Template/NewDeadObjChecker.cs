using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Connector.SaveSystem;
using Reality.TouchObject;
using TouchObjectType = Signal.C_TouchObjectType.TouchObjectType;
using Signal.Expansion;


[AddComponentMenu("")]
public class NewDeadObjChecker : StateBehaviour {

    // 図鑑に載る死に方が初めてかどうかをチェック

    [SerializeField] private StateLink _link_1;
    [SerializeField] private StateLink _link_2;

    private IUploadTimeReceivable _uploadTimeReceivable;


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

        // 初めて
        if (_uploadTimeReceivable.IsNewGetEvent())
        {
            Transition(_link_1);
        }
        else
        {
            Transition(_link_2);
        }
    }

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
