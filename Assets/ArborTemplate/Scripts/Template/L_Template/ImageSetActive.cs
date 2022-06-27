using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using UnityEngine.UI;

[AddComponentMenu("")]
public class ImageSetActive : StateBehaviour {
    // Use this for initialization

    // SpriteのSetActiveを切り替える処理

    [Header("ImageのSetActiveを切り替える")]

    [SerializeField] private StateLink link;

    [SerializeField, Tooltip("切り替えたいSprite")] private string _imageObjName;
    [SerializeField, Tooltip("切り替えスイッチ")] private bool _activeFlg;

    private Image _img;


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
        if (_img == null)
        {
            _img = ArborObjectContainer.GetObject(_imageObjName).GetComponent<Image>();

            _img.enabled = _activeFlg;
            Transition(link);
        }

    }
}

