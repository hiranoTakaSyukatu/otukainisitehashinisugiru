using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Connector.SaveSystem;
using Reality.TouchObject;
using TouchObjectType = Signal.C_TouchObjectType.TouchObjectType;
using Signal.Expansion;

[AddComponentMenu("")]
public class DeadEventResultUpdater : StateBehaviour
{
    // 死亡イベントをセーブする処理

    [Header("死亡イベントをセーブ")]

    private IUploadTimeReceivable _uploadTimeReceivable;
    [SerializeField,Tooltip("セーブしたいイベント")]
    private TouchObjectType _touchObjectType;
    [SerializeField]
    private StateLink _link;
    // Use this for initialization
    void Start()
    {

    }

    // Use this for awake state
    public override void OnStateAwake()
    {
        _uploadTimeReceivable ??= _uploadTimeReceivable.Injection();
    }

    // Use this for enter state
    public override void OnStateBegin()
    {
        _uploadTimeReceivable.DeadEventReceive((int)_touchObjectType);
        Transition(_link);

        Debug.Log(_uploadTimeReceivable.IsNewGetEvent());
    }

    // Use this for exit state
    public override void OnStateEnd()
    {
    }

    // OnStateUpdate is called once per frame
    public override void OnStateUpdate()
    {
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }
}
