using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDethp : MonoBehaviour
{
    [SerializeField] private int num;
    [SerializeField] Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();

        _camera.depth = num;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
