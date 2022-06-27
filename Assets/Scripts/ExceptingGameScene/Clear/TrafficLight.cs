using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    //�M���@�̃Q�[���I�u�W�F�N�g
    [SerializeField] GameObject tL_Obj;
    [SerializeField] Sprite tL_Red;
    [SerializeField] Sprite tL_Yellow;
    //���C�g�̃Q�[���I�u�W�F�N�g
    [SerializeField] GameObject bigLight_Green;
    [SerializeField] GameObject bigLight_Yellow;
    [SerializeField] GameObject bigLight_Red;
    [SerializeField] GameObject smallLight_Red;
    [SerializeField] GameObject smallLight_Green;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("TLManager");
    }

    IEnumerator TLManager()//�M���@����
    {
        yield return new WaitForSeconds(3f);
        tL_Obj.GetComponent<SpriteRenderer>().sprite = tL_Yellow;
        bigLight_Green.SetActive(false);
        bigLight_Yellow.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        tL_Obj.GetComponent<SpriteRenderer>().sprite = tL_Red;
        bigLight_Yellow.SetActive(false);
        bigLight_Red.SetActive(true);
        smallLight_Red.SetActive(false);
        smallLight_Green.SetActive(true);
    }
}
