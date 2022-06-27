using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Arbor;

[AddComponentMenu("")]
public class FadeOut : StateBehaviour
{

    // 死んだ時のフェード処理

    [Header("死んだ時のフェードイベント")]

    [SerializeField] private StateLink link;

    [SerializeField, Tooltip("フェードさせるSprite")] private Sprite _sprite;
    [SerializeField, Tooltip("小さくする座標")] private Vector3 _shrinkVec;
    [SerializeField, Tooltip("大きさを戻す座標")] private Vector3 _boundVec;
    [SerializeField, Tooltip("最後に小さくする座標")] private Vector3 _returnVec;

    [SerializeField, Tooltip("小さくする時間")] private float _shrinkTime;
    [SerializeField, Tooltip("大きさを戻す時間")] private float _boundTime;
    [SerializeField, Tooltip("最後に小さくする時間")] private float _returnTime;

    private SpriteRenderer _fadeSprite;
    private GameObject _fadeoutObj;
    private Transform _playerPos;

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
        ScaleChange();
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }


    // 大きさを変更する処理
    private void ScaleChange()
    {
        if (_fadeoutObj == null)
        {
            _fadeoutObj = ArborObjectContainer.GetObject("FadeOutObj");
        }

        if (_playerPos == null)
        {
            _playerPos = ArborObjectContainer.GetObject("PlayerObj").GetComponent<Transform>();
        }

        if (_fadeSprite == null)
        {
            _fadeSprite = _fadeoutObj.GetComponent<SpriteRenderer>();
            _fadeSprite.transform.position = _playerPos.position;
            _fadeSprite.sprite = _sprite;
            _fadeSprite.enabled = true;
            _fadeSprite.transform.DOScale(_shrinkVec, _shrinkTime)
                                 .OnComplete(() =>
                                 {
                                     _fadeSprite.transform.DOScale(_boundVec, _boundTime)
                                              .OnComplete
                                              (() =>
                                              {
                                                  _fadeSprite.transform.DOScale(_returnVec, _returnTime);
                                                  Transition(link);
                                              }
                                         );
                                 });
        }


    }
}
