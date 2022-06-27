using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] cloud; //雲のオブジェクト
    Vector3[] genePos = new Vector3[4];
    float generateTimer = 0; //生成時間計測
    const float SETTIME = 10; //生成時間初期化
    void Start()
    {
        genePos[0] = new Vector3(12.5f, 11f, 0);
        genePos[1] = new Vector3(14f, 10.5f, 0);
        genePos[2] = new Vector3(14f, 8f, 0);
        genePos[3] = new Vector3(14.5f, 5.5f, 0);
        //genePos[4] = new Vector3(14f, 3.5f, 0);
    }

    void Update()
    {
        generateTimer += Time.deltaTime;
        if(generateTimer >= SETTIME)
        {
            Debug.Log("kumo");
            Instantiate(cloud[Random.Range(0, cloud.Length)], genePos[Random.Range(0,genePos.Length)], Quaternion.identity);
            generateTimer = 0;
        }
    }
}
