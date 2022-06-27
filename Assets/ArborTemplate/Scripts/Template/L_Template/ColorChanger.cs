using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using UnityEngine.UI;

[AddComponentMenu("")]
public class ColorChanger : StateBehaviour {
    // Use this for initialization

    [Header("Colorを変更する")]

    [SerializeField] private StateLink link;

    [SerializeField, Tooltip("TextのバインダーKey")] private string _textObjName;
    [SerializeField, Tooltip("変更用の色")]   private Color _color;

    private Text _text;


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
        if (_text == null)
        {
            _text = ArborObjectContainer.GetObject(_textObjName).GetComponent<Text>();

            _text.color = _color;
            Transition(link);
        }

    }
}
