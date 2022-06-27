using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class AudioVolumeControler : StateBehaviour {

    // 音量を調節する処理

    [Header("音量を調節する")]

    [SerializeField] private StateLink link;
    [SerializeField, Tooltip("変更したいオブジェクトのバインダーKey")] private string _name;
    [SerializeField, Tooltip("音量")] private float _volSize;

    private AudioSource audioSource;

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
        AudioVolume();

    }

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}

    private void AudioVolume()
    {
        if (!audioSource)
        {
            audioSource = ArborObjectContainer.GetObject(_name).GetComponent<AudioSource>();
            audioSource.volume = _volSize;
            audioSource = null;
            Transition(link);
        }

    }
}
