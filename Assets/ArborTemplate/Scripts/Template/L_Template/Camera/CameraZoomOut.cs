using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Arbor;

[AddComponentMenu("")]
public class CameraZoomOut : StateBehaviour
{

    // カメラをズームアウトする処理

    [Header("カメラズームアウト")]

    [SerializeField] private StateLink link;

    [SerializeField, Tooltip("カメラがズームアウトする速さの値")] private float _cameraZoomNum = 0.02f;
    [SerializeField, Tooltip("カメラがズームアウトする最大値")] 　private float _MaxCamera = 6;

    private Camera _mainCamera;



    // Use this for initialization
    void Start()
    {
        _mainCamera = GameObject.Find("Camera").GetComponent<Camera>();
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
        ZoomOut();
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }


    // ズームアウト処理
    private void ZoomOut()
    {
        if (!_mainCamera) return;
        if (_mainCamera.orthographicSize < _MaxCamera)
        {
            _mainCamera.orthographicSize += _cameraZoomNum;
        }
        else
        {
            Transition(link);
        }

    }
}
