using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Connector.PlayerMove;
using Zenject;

public class PlayerAutoMove : MonoBehaviour
{
    [Inject]
    IInputReceivable _input;
    private Queue<Vector3> vector3Queue = new Queue<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        _input.IsRunButtonStateChange(false);
        _input.GetObjectDistance += x => 0.5f;

        InputKeyEnQueue(Vector3.left, 570);
        InputKeyEnQueue(Vector3.up,   1050);
        InputKeyEnQueue(Vector3.left, 1  );
        InputKeyEnQueue(Vector3.zero, 300);
        InputKeyEnQueue(Vector3.left, 400);
        InputKeyEnQueue(Vector3.down, 320);
        InputKeyEnQueue(Vector3.left, 1);
        //InputKeyEnQueue(Vector3.zero, 30);
        InputKeyEnQueue(Vector3.left, 120);
        InputKeyEnQueue(Vector3.zero, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vector3Queue.Count < 1) return;
        _input.CurrentMoveDir(vector3Queue.Dequeue());
    }

    void InputKeyEnQueue(Vector3 vector3,int freamNum)
    {
        for (int i = 0; i < freamNum; i++)
        {
            vector3Queue.Enqueue(vector3);
        }
    }
}
