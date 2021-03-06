using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class SpriteChanger : StateBehaviour
{
    // Use this for initialization

    // Spriteを変更する処理

    [SerializeField] private StateLink link;

    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _objName;

    private SpriteRenderer _srObj;

    void Start()
    {
        _srObj = GameObject.Find(_objName).GetComponent<SpriteRenderer>();
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
        if (_srObj != null)
        {
            _srObj.sprite = _sprite;
   
            Transition(link);
        }
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }
}
