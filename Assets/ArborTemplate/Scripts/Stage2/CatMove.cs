using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using DG.Tweening;

[AddComponentMenu("")]
public class CatMove : StateBehaviour
{
    // 猫の動き処理

    [SerializeField] private StateLink link;

    [SerializeField] private string _animName;
    [SerializeField] private Vector3 _catPos1;
    [SerializeField] private float _time;

    private GameObject _catObj;
    private Animator _animator;
    private Vector2 _startPos;
    private float _count;

    // Use this for initialization
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
        _count = 0;
        if (_catObj != null)
        {
            _startPos = _catObj.transform.position;
        }
       
    }

    // Use this for exit state
    public override void OnStateEnd()
    {
    }

    // OnStateUpdate is called once per frame
    public override void OnStateUpdate()
    {
        _count += Time.deltaTime / _time;
        if (_count > 1.0f)
        {
            _animator.SetTrigger(_animName);
            _catObj = null;
            Transition(link);
        }
        if (_catObj == null)
        {
            _catObj = ArborObjectContainer.GetObject("CatObj");
            _startPos = _catObj.transform.position;
            Debug.Log(_startPos);
            _animator = _catObj.GetComponent<Animator>();
            //_catObj.transform.DOMove(_catPos1, _time).OnComplete(() =>
            //{
            //    _animator.SetTrigger(_animName);

            //    _catObj = null;
            //    Transition(link);
            //});
        }
        _catObj.transform.position = Vector2.Lerp(_startPos, _catPos1, _count);
    }


    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }
}
