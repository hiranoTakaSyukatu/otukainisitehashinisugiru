using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NameMove : MonoBehaviour
{
    [SerializeField] GameObject creatorsNameObj;
    [SerializeField] Vector2 endVec;
    private float second = 1;
    bool once = true;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //private void DTMove()
    //{
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(once == true) { creatorsNameObj.transform.DOMove(endVec, second); }
        once = false;
    }
}
