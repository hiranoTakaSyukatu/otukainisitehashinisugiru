using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class ColliderSetActiveFlg_Capsule : StateBehaviour {
    // Use this for initialization
    // コライダーのSetActiveを切り替える処理(カプセルコライダー専用)


    [SerializeField] private StateLink link;

    private CapsuleCollider2D _objCol;

    [SerializeField] private string _objName;
    [SerializeField] private bool _colFlg;

    void Start()
    {
        _objCol = ArborObjectContainer.GetObject(_objName).GetComponent<CapsuleCollider2D>();
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
        if (_objCol != null)
        {
            _objCol.enabled = _colFlg;
            Transition(link);

        }
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }
}
