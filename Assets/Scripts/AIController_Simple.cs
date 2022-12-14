using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController_Simple : AIController
{
    // Start is called before the first frame update
    public override void Start()
    {
        //Starts by idling
        ChangeState(AIStates.Idle);
    }

    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions();
    }

    public override void MakeDecisions()
    {
        //Finite state machine time

        switch (currentState)
        {
            case AIStates.Idle:
                DoIdleState();
                if (IsTimePassed(1))
                {
                    ChangeState(AIStates.ChooseTarget);
                }
                break;
            case AIStates.ChooseTarget:
                DoTargetPlayer1State();
                if (IsTimePassed(1))
                {
                    if (IsCanHear(AITarget))
                    {
                        if (AITarget != null)
                        {
                            ChangeState(AIStates.Attack);
                        }
                    }
                    else
                    {
                        ChangeState(AIStates.Idle);
                    }
                    
                }
                break;
            case AIStates.Patrol:
                DoPatrolState();
                if (IsTimePassed(10))
                {
                    ChangeState(AIStates.Idle);
                }
                break;
            case AIStates.Attack:
                DoAttackState();
                ChangeState(AIStates.Patrol);
                break;

        }
    }


}
