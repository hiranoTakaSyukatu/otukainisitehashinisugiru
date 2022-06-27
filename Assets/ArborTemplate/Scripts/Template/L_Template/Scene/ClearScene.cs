using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using UnityEngine.SceneManagement;

[AddComponentMenu("")]
public class ClearScene : StateBehaviour {

    // シーン遷移処理

	[SerializeField] private string _name;

	// Start is called before the first frame update
	void Start()
	{
		SceneManager.LoadScene(_name);
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
