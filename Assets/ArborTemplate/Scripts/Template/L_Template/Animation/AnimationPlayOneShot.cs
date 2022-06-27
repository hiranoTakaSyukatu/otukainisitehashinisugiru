using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class AnimationPlayOneShot : StateBehaviour
{

    // Arborアニメーター処理
    [SerializeField] private StateLink link;

    [SerializeField] private string _animationName;
    [SerializeField] private float _animationTime;
    [SerializeField] private AnimationClip animationClip;

    private Animator _anim;
    private float _timeCount = 0.0f;

    // Use this for initialization
    void Start()
    {
        _anim = GameObject.Find("AnimationContanier").GetComponent<Animator>();
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

        if (_anim != null)
        {
            _anim.Play(_animationName);
            Debug.Log(_animationName);
            _timeCount += Time.deltaTime;
        }
        if (_animationTime < _timeCount)
        {
            Transition(link);
        }
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }
}
