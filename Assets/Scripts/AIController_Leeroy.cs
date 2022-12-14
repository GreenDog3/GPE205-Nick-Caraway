using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController_Leeroy : AIController
{
    // Start is called before the first frame update
    public override void Start()
    {
        //Start by Idling
        ChangeState(AIStates.Idle);
    }

    // Update is called once per frame
    public override void Update()
    {
        if (pawn != null)
        {
            MakeDecisions();
        }
        
    }
    
    public override void MakeDecisions()
    {
        //Leeroy's strategy is to chase you and mash the shoot button trying to shoot more.
        switch(currentState)
        {
            case AIStates.Idle:
                DoIdleState();
                if (IsTimePassed(1))
                {
                    ChangeState(AIStates.ChooseTarget);
                }
                break;
            case AIStates.ChooseTarget:
                DoChangeTargetState();
                if (IsCanHear(AITarget))
                {
                    if (AITarget != null)
                    {
                        ChangeState(AIStates.Chase);
                    }                  
                }
                else
                {
                    ChangeState(AIStates.Attack);
                }
                
                break;
            case AIStates.Chase:
                DoChaseState();
                if (IsTimePassed(2))
                {
                    ChangeState(AIStates.Attack);
                }
                break;
            case AIStates.Attack:
                DoAttackState();
                ChangeState(AIStates.ChooseTarget);
                break;
        }
    }
}
