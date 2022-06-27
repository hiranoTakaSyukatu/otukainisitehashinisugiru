using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using ArborSystem.Presenter;
using UniRx;

[AddComponentMenu("")]
public class InputStateChange : StateBehaviour {

    // Playerの入力処理のステート変更処理

    [Header("Playerの入力切り替え")]

    [SerializeField] private StateLink link;
	private InputPresenter _inputPresenter;

	// Use this for initialization
	void Start () {
		_inputPresenter = FindObjectOfType<InputPresenter>();
		Debug.Log(_inputPresenter);
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
		if (_inputPresenter)
        {
			_inputPresenter.Observer.OnNext(Unit.Default);
			Transition(link);
		}
	}

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
