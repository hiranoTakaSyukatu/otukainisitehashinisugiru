using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class SpriteSetActive : StateBehaviour
{

    // SpriteのSetActiveを切り替える処理

    [Header("SpriteのSetActiveを切り替える")]

    [SerializeField] private StateLink link;

    [SerializeField, Tooltip("切り替えたいSprite")] private string _spriteObjName;
    [SerializeField, Tooltip("切り替えスイッチ")]   private bool _activeFlg;

    private SpriteRenderer _sr;


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
        SetActiveSwitch();
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }


    // SetActive切り替え処理
    private void SetActiveSwitch()
    {
        if (_sr == null)
        {
            _sr = ArborObjectContainer.GetObject(_spriteObjName).GetComponent<SpriteRenderer>();

            _sr.enabled = _activeFlg;
            Transition(link);
        }

    }
}
