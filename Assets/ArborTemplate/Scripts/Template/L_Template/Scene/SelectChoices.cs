using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using UnityEngine.UI;

[AddComponentMenu("")]
public class SelectChoices : StateBehaviour {

    // 選択肢処理(選択が3個の場合)

    [Header("選択イベント(3択専用)")]

    [SerializeField] private StateLink link;

    [SerializeField, Tooltip("選択されるテキスト")] private string[] _choicesText;
    [SerializeField, Tooltip("表示用スプライト")] private Sprite[] _sprite;
    [SerializeField, Tooltip("X軸位置調整用")] private float _offset_X;
    [SerializeField, Tooltip("Y軸位置調整用")] private float _offset_Y;

    private GameObject _SelectChoicesObj;
    private Transform _playerPos;

    private Text _text_0;
    private Text _text_1;
    private Text _text_2;
    private SpriteRenderer _backSprite;
    private SpriteRenderer _selectSprite;

    private Vector3 _textPos_0;
    private Vector3 _textPos_1;
    private Vector3 _textPos_2;

    private int _selectNum = 0;
    private int _sentNum;


    // Use this for initialization
    void Start () {
	
	}

	// Use this for awake state
	public override void OnStateAwake() {
	}

	// Use this for enter state
	public override void OnStateBegin() {
	}

	// Use this for exit state
	public override void OnStateEnd() {
	}
	
	// OnStateUpdate is called once per frame
	public override void OnStateUpdate() {
        Display();
    }

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}


    // 表示処理
    private void Display()
    {
        if (_SelectChoicesObj == null)
        {
            _SelectChoicesObj = ArborObjectContainer.GetObject("SelectChoicesObj");
            _playerPos = ArborObjectContainer.GetObject("PlayerObj").GetComponent<Transform>();

            _SelectChoicesObj.transform.position = new Vector3
                                                    (
                                                        _playerPos.position.x + _offset_X,
                                                        _playerPos.position.y + _offset_Y,
                                                        0
                                                     );

            _backSprite = ArborObjectContainer.GetObject("BackSpriteObj").GetComponent<SpriteRenderer>();
            _selectSprite = ArborObjectContainer.GetObject("SelectSpriteObj").GetComponent<SpriteRenderer>();

            _text_0 = ArborObjectContainer.GetObject("Text_0").GetComponent<Text>();
            _text_1 = ArborObjectContainer.GetObject("Text_1").GetComponent<Text>();
            _text_2 = ArborObjectContainer.GetObject("Text_2").GetComponent<Text>();

            _textPos_0 = _text_0.transform.position;
            _textPos_1 = _text_1.transform.position;
            _textPos_2 = _text_2.transform.position;

            _text_0.text = _choicesText[0];
            _text_1.text = _choicesText[1];
            _text_2.text = _choicesText[2];

            _backSprite.sprite = _sprite[0];
            _selectSprite.sprite = _sprite[1];
        }
        else
        {
            Select();
        }

    }

    // 選択処理
    private void Select()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            _selectNum++;

            if (_selectNum == 3) _selectNum = 0;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            _selectNum--;
            if(_selectNum == -1)_selectNum = 2;
        }

        switch (_selectNum)
        {
            case 0:
                _selectSprite.transform.position = _textPos_0;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _sentNum = 0;
                    Transition(link);
                }

                break;
            case 1:
                _selectSprite.transform.position = _textPos_1;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _sentNum = 1;
                    Transition(link);
                }
                break;
            case 2:
                _selectSprite.transform.position = _textPos_2;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _sentNum = 2;
                    Transition(link);
                }
                break;
            default:
                break;

        }
    }

    // 選択した情報を渡す処理(一応残しとく)
    public int SentSelectNum()
    {
        return _sentNum;
    }
}
