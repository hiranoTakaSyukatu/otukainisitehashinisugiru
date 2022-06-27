using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using DG.Tweening;

[AddComponentMenu("")]
public class PlayerDeadPuddle : StateBehaviour
{
    // プレイヤーが水たまりに吸い込まれる処理


    [SerializeField] private StateLink link;
    [SerializeField, Tooltip("Plyaerが回る角度")]      private float _playerRotation;
    [SerializeField, Tooltip("1つの動作が終わる時間")] private float _time;

    private GameObject _playerObj;
    private const float offset_X = -2.17f;
    private const float offset_Y = 0.818f;

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
        PlayerRotation();
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }


    // Playerの回転 + 縮小処理
    private void PlayerRotation()
    {
        // 謎解決してない

        if (_playerObj == null)
        {
            _playerObj = ArborObjectContainer.GetObject("PlayerObj");

            _playerObj.transform.DOMove(new Vector3(offset_X, offset_Y, 0), _time);
            _playerObj.transform.DOScale(new Vector3(0, 0, 0), _time);
            _playerObj.transform.rotation = new Quaternion(0, 0, 0, 0);
            _playerObj.transform.DORotate(new Vector3(0, _playerObj.transform.rotation.y, _playerRotation), _time);

            Transition(link);
        }
    }
}
