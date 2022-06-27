using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using Connector.Player;
using TouchObjectType = Signal.C_TouchObjectType.TouchObjectType;
using Reality.Player;
using Signal.Expansion;


[AddComponentMenu("")]
public class Input_Dash : StateBehaviour
{

    // ダッシュをしてる時間でイベントを実行する処理

    [SerializeField] private StateLink link;
    [SerializeField] private TouchObjectType _enum;


    private IObjectRecevetable objectRecevetable;

    [SerializeField, Tooltip("転ぶまでの時間")] private float _eventTime = 7;
    private float _time;

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
        InputTimeCount();
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }


    // 入力している間に時間を計測する処理
    private void InputTimeCount()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _time += Time.deltaTime;

            if (_time > _eventTime)
            {
                objectRecevetable ??= objectRecevetable.Injection();
                objectRecevetable.ObjectRecevetable(_enum);
                _time = 0;
                Transition(link);
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _time = 0;
            Transition(link);
        }

    }
}
