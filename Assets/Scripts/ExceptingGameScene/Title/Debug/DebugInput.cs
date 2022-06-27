using Connector.Player;
using Signal.Expansion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchObjectType = Signal.C_TouchObjectType.TouchObjectType;

public class DebugInput : MonoBehaviour
{
    [SerializeField]
    string sceneName;
    IObjectRecevetable objectRecevetable;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            objectRecevetable.Injection().ObjectRecevetable(TouchObjectType.YANKEY);
        }
    }
}
