using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using UnityEngine.UI;

[AddComponentMenu("")]
public class Conversation : StateBehaviour
{

    // 会話イベント処理

    [Header("会話イベント")]

    [SerializeField] private StateLink link;

    [SerializeField, Tooltip("キャラのセリフ"), Multiline(2)] private string _charaText;
    [SerializeField, Tooltip("テキストの大きさ")] private int _textSize;
    [SerializeField, Tooltip("喋るキャラのバインダーKey")] private string _charaName;
    [SerializeField, Tooltip("X座標調整用")] private float _offset_X;
    [SerializeField, Tooltip("XY座標調整用")] private float _offset_Y;
    [SerializeField, Tooltip("吹き出し用Sprite")] private Sprite _sprite;

    private GameObject _conversationObj;
    private Transform _charactorPos;
    private Text _text;
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
        ConversationDisplay();
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }



    // 表示処理
    private void ConversationDisplay()
    {
        if (_conversationObj == null)
        {
            _conversationObj = ArborObjectContainer.GetObject("ConversationObj");


            _charactorPos = ArborObjectContainer.GetObject(_charaName).GetComponent<Transform>();

            _text = _conversationObj.GetComponentInChildren<Text>();
            _sr = _conversationObj.GetComponentInChildren<SpriteRenderer>();


            _conversationObj.transform.position = new Vector3(_charactorPos.position.x + _offset_X,
                                                              _charactorPos.position.y + _offset_Y,
                                                              0);
            _text.enabled = true;
            _sr.enabled = true;

            _text.fontSize = _textSize;
            _text.text = _charaText;
            _sr.sprite = _sprite;

            Transition(link);
        }


    }
}
