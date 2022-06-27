using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using DG.Tweening;

[AddComponentMenu("")]
public class FadeOutSprite : StateBehaviour {
    // Use this for initialization

    // Spriteをフェードする処理

    [Header("Spriteをフェードするイベント")]

    [SerializeField] private StateLink link;

    [SerializeField, Tooltip("フェードするSprite")] private Sprite _sprite;
    [SerializeField, Tooltip("フェードする時間")] private float changeTime;

    private SpriteRenderer _srObj;

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
        Fade();
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }

    private void Fade()
    {
        if (_srObj == null)
        {
            _srObj = ArborObjectContainer.GetObject("FadeSpriteObj").GetComponent<SpriteRenderer>();
            _srObj.DOColor(new Color(0, 0, 0, 1), 0);
            _srObj.enabled = true;
            _srObj.sprite = _sprite;
            _srObj.DOColor(new Color(0, 0, 0, 0), changeTime);
            Transition(link);
        }

    }
}
