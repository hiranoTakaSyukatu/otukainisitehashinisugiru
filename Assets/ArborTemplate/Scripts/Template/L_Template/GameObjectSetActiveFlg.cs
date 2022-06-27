using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class GameObjectSetActiveFlg : StateBehaviour
{
    // Use this for initialization

    // GameObjectのSetActiveを切り替える処理

    [Header("GameObjectのSetActive切り替え")]

    [SerializeField] private StateLink link;

    private GameObject _obj;

    [SerializeField] private string _objName;
    [SerializeField] private bool _activeFlg;

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
        if (_obj == null)
        {
            _obj = GameObject.Find(_objName);
            _obj.gameObject.SetActive(_activeFlg);

            Debug.Log(_obj);

            _obj = null;
            Transition(link);

        }
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }
}
