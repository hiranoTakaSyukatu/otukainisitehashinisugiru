using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Common.Model;

[AddComponentMenu("")]
public class StageChanger : StateBehaviour {

    // Stageを変更する処理

    [Header("Stageを変更")]

    [SerializeField] private StateLink link;
    [SerializeField] private int _stageNum;

    private GameSceneMover gameSceneMover;

    // Use this for initialization
    void Start () {

		gameSceneMover = new GameSceneMover();

        gameSceneMover.SceneMove(_stageNum);
        Transition(link);
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
	}

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
