using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class SpriteDisplayer : StateBehaviour {

    // 特定の画像を表示させる

    [Header("いいいいいいい")]

    [SerializeField] private StateLink link;

    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _spriteName;
    [SerializeField] private string _objName;
    [SerializeField] private float _offset_X;
    [SerializeField] private float _offset_Y;

    private GameObject _spriteObj;
    private SpriteRenderer _sr;
    private Transform _objtransform;

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

        if(_objtransform == null)
        {
            _objtransform = GameObject.Find(_objName).GetComponent<Transform>();
        }

        if(_spriteObj == null)
        {

            _spriteObj = GameObject.Find(_spriteName);
            _spriteObj.transform.position = new Vector3(
                                          _objtransform.position.x + _offset_X, 
                                          _objtransform.position.y + _offset_Y, 
                                          0);
        }

        if(_sr == null)
        {
            _sr = _spriteObj.GetComponent<SpriteRenderer>();
            _sr.sprite = _sprite;
            _sr.enabled = true;
            Transition(link);
        }

    }

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
