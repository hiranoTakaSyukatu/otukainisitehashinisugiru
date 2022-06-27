using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class DisplayPosChange : StateBehaviour
{

    // 表示を切り替え処理(移動させる処理)

    [Header("オブジェクトを移動")]

    [SerializeField] private StateLink link;

    [SerializeField, Tooltip("移動させたいObjectのバインダーKey")] private string _objStr;
    [SerializeField, Tooltip("移動位置")] private Vector3 _changePos;

    private GameObject _positionChangeObj;

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
        Move();
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }


    // 移動処理
    private void Move()
    {
        if (_positionChangeObj == null)
        {
            _positionChangeObj = ArborObjectContainer.GetObject(_objStr);

            _positionChangeObj.transform.position = _changePos;

            _positionChangeObj = null;
            Transition(link);
        }
    }
}
