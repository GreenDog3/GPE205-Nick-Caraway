using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Controller_Simple : AI_Controller
{
    // Start is called before the first frame update
    public override void Start()
    {
        //Make sure it starts idling
        ChangeState(AIStates.Idle);
    }

    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions();
    }

    public override void MakeDecisions()
    {
        //finite state machine
        //based? based on what? the current state
        switch ( currentState)
        {
            case AIStates.Idle:
                DoIdleState();
                if (IsTimePassed(3))
                {
                    ChangeState(AIStates.Chase);
                }
                break;
            case AIStates.Chase:
                DoChaseState();
                if (IsTimePassed(1))
                {
                    ChangeState(AIStates.Idle);
                }
                break;
            case AIStates.ChooseTarget:
                DoChangeTargetState();
                ChangeState(AIStates.Chase);
                break;
        }
    }
}
