using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    float lifeTime = 30; //¶‘¶ŠÔ
    float moveSpeed = 0.5f; //ˆÚ“®‘¬“x
    Vector3 moveVec = new Vector3(-2, -1, 0); //ˆÚ“®•ûŒü
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.position += moveVec * moveSpeed * Time.deltaTime;
        Destroy(this.gameObject, lifeTime);
    }
}
