using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    float lifeTime = 30; //生存時間
    float moveSpeed = 0.5f; //移動速度
    Vector3 moveVec = new Vector3(-2, -1, 0); //移動方向
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.position += moveVec * moveSpeed * Time.deltaTime;
        Destroy(this.gameObject, lifeTime);
    }
}
