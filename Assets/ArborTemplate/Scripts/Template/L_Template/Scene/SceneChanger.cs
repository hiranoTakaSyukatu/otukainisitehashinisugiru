using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Reality.SceneAssetManager;
using Common.Model;

[AddComponentMenu("")]
public class SceneChanger : StateBehaviour
{

    // 特定のStageに変更する処理

    [Header("ステージを変更")]

    [SerializeField] private StateLink link;
    private int _stageNum;

    // Use this for initialization
    void Start()
    {
        _stageNum = FindObjectOfType<LoadStarter>().GetNowStageNum();
        GameSceneMover gameSceneMover = new GameSceneMover();
        gameSceneMover.SceneMove(_stageNum);
        Transition(link);
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

    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }
}
