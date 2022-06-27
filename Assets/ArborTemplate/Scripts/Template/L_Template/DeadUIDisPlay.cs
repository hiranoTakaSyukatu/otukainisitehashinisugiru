using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using UnityEngine.UI;

[AddComponentMenu("")]
public class DeadUIDisPlay : StateBehaviour {

    // 死んだアイコンを表示する処理

    [Header("死んだ時のUI表示")]

    [SerializeField] private StateLink link;

    [SerializeField, Tooltip("ImageアイコンのバインダーKey")]  private string _imageName;
    [SerializeField, Tooltip("Text_0のバインダーKey")]         private string _textName_0;
    [SerializeField, Tooltip("Text_1のバインダーKey")]         private string _textName_1;
    [SerializeField, Tooltip("Text_2のバインダーKey")]         private string _textName_2;
    [SerializeField, Tooltip("NewDeadTextのバインダーKey")]    private string _newDeadName;

    [SerializeField, Tooltip("Newのアクティブスイッチ")] private bool _newDeadActiveFlg;

    [SerializeField, Tooltip("死亡イベントアイコンSprite")] private Sprite  _imageUI;
    [SerializeField, Tooltip("Cause of Death")] private string _textUI_0;
    [SerializeField, Tooltip("死亡イベントの題名")] private string _textUI_1;
    [SerializeField, Tooltip("死亡イベント説明")] private string _textUI_2;
    [SerializeField, Tooltip("")] private string _newDeadText;

    private Image _image;
    private Image _InputImage;
    private Text _text_0;
    private Text _text_1;
    private Text _text_2;
    private Text _newDead;

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

        if(_image == null)
        {
            _image      = ArborObjectContainer.GetObject(_imageName).GetComponent<Image>();
            _InputImage = ArborObjectContainer.GetObject("InputImageObj").GetComponent<Image>();
            _text_0     = ArborObjectContainer.GetObject(_textName_0).GetComponent<Text>();
            _text_1     = ArborObjectContainer.GetObject(_textName_1).GetComponent<Text>();
            _text_2     = ArborObjectContainer.GetObject(_textName_2).GetComponent<Text>();
            _newDead    = ArborObjectContainer.GetObject(_newDeadName).GetComponent<Text>();

            _image.sprite      = _imageUI;

            _text_0.text  = _textUI_0;
            _text_1.text  = _textUI_1;
            _text_2.text  = _textUI_2;
            _newDead.text = _newDeadText;
 
            _image.enabled          = true;
            _InputImage.enabled     = true;
            _text_0.enabled         = true;
            _text_1.enabled         = true;
            _text_2.enabled         = true;
            _newDead.enabled        = _newDeadActiveFlg;

            Transition(link);
        }
    }

	// OnStateLateUpdate is called once per frame, after Update has finished.
	public override void OnStateLateUpdate() {
	}
}
