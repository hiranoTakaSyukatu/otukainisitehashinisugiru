using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameSceneAsset/StageDB")]
public class StageDB : ScriptableObject
{
    public int stageNum;
    public static readonly int MaxStageNum = 2;
    public GameObject fieldObject;
    public List<GameObject> deadEvent;
    public List<GameObject> conversionEvent;
    public List<GameObject> otherEvent;
}
