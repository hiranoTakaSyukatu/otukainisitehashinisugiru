using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class ChoiecesAnswer : StateBehaviour
{

    // 選択の分岐処理

    [SerializeField] private StateLink link1;
    [SerializeField] private StateLink link2;
    [SerializeField] private StateLink link3;

    private SelectChoices _selectChoices;


    // Use this for initialization
    void Start()
    {

    }

    // Use this for awake state
    public override void OnStateAwake()
    {
    }

    // Use this for enter state
    public override void OnStateBegin()
    {
    }

    // Use this for exit state
    public override void OnStateEnd()
    {
    }

    // OnStateUpdate is called once per frame
    public override void OnStateUpdate()
    {

        if (_selectChoices == null)
        {
            _selectChoices = GetComponent<SelectChoices>();

            switch (_selectChoices.SentSelectNum())
            {
                case 0:
                    Transition(link1);
                    break;
                case 1:
                    Transition(link2);
                    break;
                case 2:
                    Transition(link3);
                    break;
            }
        }

    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }
}
