using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController_Goomba : AIController
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
        //The Goomba's main attack strategy will be trying to push the player off the map.

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
                DoChangeTargetState();
                if (IsTimePassed(1))
                {
                    if (IsCanHear(AITarget))
                    {
                        if (AITarget != null)
                        {
                            ChangeState(AIStates.Chase);
                        }
                    }
                    else
                    {
                        ChangeState(AIStates.Idle);
                    }
                    
                }
                break;
            case AIStates.Chase:
                DoChaseState();
                
                if (IsTimePassed(10))
                {
                    ChangeState(AIStates.Idle);
                }
                break;

        }
    }
}
