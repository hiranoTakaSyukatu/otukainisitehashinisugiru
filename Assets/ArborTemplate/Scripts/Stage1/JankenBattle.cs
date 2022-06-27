using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

[AddComponentMenu("")]
public class JankenBattle : StateBehaviour
{

    // じゃんけんの結果を返す処理

    [SerializeField] private StateLink link1;
    [SerializeField] private StateLink link2;
    [SerializeField] private StateLink link3;
    [SerializeField] private StateLink link4;
    [SerializeField] private StateLink link5;
    [SerializeField] private StateLink link6;

    private SelectChoices _selectChoices;
    private int _randNum;
    private int _kidSelect;

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

            _randNum = Random.Range(0,2);

            Debug.Log(_randNum);

            // 勝ち
            if(_randNum == 0)
            {
                switch (_selectChoices.SentSelectNum())
                {
                    case 0:
                        BattleResult(1, link1);
                        break;
                    case 1:
                        BattleResult(2, link2);
                        break;
                    case 2:
                        BattleResult(0, link3);
                        break;
                }
            }
            // 負け
            else
            {
                switch (_selectChoices.SentSelectNum())
                {
                    case 0:
                        BattleResult(2,link4);
                        break;
                    case 1:
                        BattleResult(0, link5);
                        break;
                    case 2:
                        BattleResult(1, link6);
                        break;
                }

            }
        }
    }

    // OnStateLateUpdate is called once per frame, after Update has finished.
    public override void OnStateLateUpdate()
    {
    }

    private void BattleResult(int num, StateLink link)
    {
        _kidSelect = num;
        _selectChoices = null;
        Transition(link);
    }
}
