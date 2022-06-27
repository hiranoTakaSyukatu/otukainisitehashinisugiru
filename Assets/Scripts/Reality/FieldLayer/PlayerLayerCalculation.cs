using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayerCalculation : MonoBehaviour
{
    [SerializeField]
    private float _offset;

    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        var tmp = transform.position;
        tmp.z = transform.position.y + _offset;
        _renderer.sortingOrder = -(int)(tmp.z * 100);
    }

}
