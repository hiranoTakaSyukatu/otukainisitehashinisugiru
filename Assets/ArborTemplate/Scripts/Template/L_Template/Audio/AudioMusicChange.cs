using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class AudioMusicChange : StateBehaviour {

    // BGMを変更する処理

    [SerializeField] private StateLink link;
    [SerializeField, Tooltip("変更したいオブジェクトのバインダーKey")] private string _name;
    [SerializeField, Tooltip("変更したいBGM")] private AudioClip _bgmClip;

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
	}

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
        AudioVolume();
    }

    private void AudioVolume()
    {
        if (!audioSource)
        {
            audioSource = ArborObjectContainer.GetObject(_name).GetComponent<AudioSource>();
            audioSource.clip = _bgmClip;
            audioSource.Play();
            audioSource = null;
            Transition(link);
        }

    }

}
