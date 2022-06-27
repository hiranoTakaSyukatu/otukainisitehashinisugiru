using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Arbor;

[AddComponentMenu("")]
public class CameraZoom : StateBehaviour
{

    // カメラをズームする処理

    [Header("カメラズーム")]

    [SerializeField] private StateLink link;

    [SerializeField, Tooltip("ズームする値")] private float _cameraZoomNum = 0.05f;
    [SerializeField, Tooltip("カメラをズームする最小値")] private float _minCamera = 3;


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
        Zoom();
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }


    // カメラをズームする処理
    private void Zoom()
    {
        if (!_mainCamera) return;
        if (_mainCamera.orthographicSize > _minCamera)
        {
            _mainCamera.orthographicSize -= _cameraZoomNum;
        }
        else
        {
            Transition(link);
        }
    }
}
