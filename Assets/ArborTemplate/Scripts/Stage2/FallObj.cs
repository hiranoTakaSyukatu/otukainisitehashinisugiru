using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using DG.Tweening;

[AddComponentMenu("")]
public class FallObj : StateBehaviour {
    // Use this for initialization
    // F12が落ちてくる処理

    [SerializeField] private StateLink link;

    [SerializeField] private float _fallTime;
    [SerializeField] private string _objName;

    private Transform _playerPos;
    private GameObject _obj;

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
    }

    // Use this for exit state
    public override void OnStateEnd()
    {
    }

    // OnStateUpdate is called once per frame
    public override void OnStateUpdate()
    {
        if (_playerPos == null)
        {
            _playerPos = ArborObjectContainer.GetObject("PlayerObj").GetComponent<Transform>();
            _obj = ArborObjectContainer.GetObject(_objName);

            _obj.transform.position = new Vector3
                                    (
                                        _playerPos.position.x,
                                        _playerPos.position.y + 30,
                                        _playerPos.position.z
                                    );

            _obj.transform.DOMove(new Vector3(_obj.transform.position.x, _playerPos.position.y, _obj.transform.position.z), _fallTime);
            Transition(link);
        }
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }
}
