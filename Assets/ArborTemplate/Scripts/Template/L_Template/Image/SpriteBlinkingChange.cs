using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class SpriteBlinkingChange : StateBehaviour {

    // Spriteを点滅させる処理

    [SerializeField] private StateLink link;

    [SerializeField] private Sprite _sprite_1;
    [SerializeField] private Sprite _sprite_2;
    [SerializeField] private string _objName;
    [SerializeField] private float  _switchTime;

    private SpriteRenderer _srObj;

    void Start()
    {
    }

    // Use this for awake state
    public override void OnStateAwake()
    {
    }

    // Use this for enter state
    public override void OnStateBegin()
    {
    }

    // Use this for exit state
    public override void OnStateEnd()
    {
    }

    // OnStateUpdate is called once per frame
    public override void OnStateUpdate()
    {
        if (!_srObj)
        {
            _srObj = GameObject.Find(_objName).GetComponent<SpriteRenderer>();
            StartCoroutine("SpriteChange");
        }
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }
    
    IEnumerator SpriteChange()
    {
        yield return new WaitForSeconds(_switchTime);

        _srObj.sprite = _sprite_2;

        yield return new WaitForSeconds(_switchTime);

        _srObj.sprite = _sprite_1;

        yield return new WaitForSeconds(_switchTime);

        _srObj.sprite = _sprite_2;

        yield return new WaitForSeconds(_switchTime);

        _srObj.sprite = _sprite_1;

        yield return new WaitForSeconds(_switchTime);

        _srObj.sprite = _sprite_2;

        yield return new WaitForSeconds(_switchTime);

        _srObj.sprite = _sprite_1;

        yield return new WaitForSeconds(_switchTime);

        _srObj = null;
        Transition(link);
    }
}
