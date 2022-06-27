using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class InstansiateGameObject : StateBehaviour
{

    // GameObjectPrefabを生成する処理

    [Header("GameObjectを生成")]

    [SerializeField] private StateLink link;
    [SerializeField, Tooltip("生成したいGameObject")] private GameObject _obj;

    // Use this for initialization
    void Start()
    {
        Instantiate(_obj);
        Transition(link);
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
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }
}
