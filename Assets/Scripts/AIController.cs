using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIController : Controller
{
    public enum AIStates {Idle, Chase, Attack, Flee, ChooseTarget, Patrol, Turn};
    public AIStates currentState;
    public float timeEnteredCurentState;
    public GameObject AITarget;
    public float hearingDistance;
    public List<Transform> waypoints;
    public int currentWaypoint;
    
    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void ChangeState(AIStates newState)
    {
        //Tells the AI that we entered a new state and starts counting how long we've been there
        timeEnteredCurentState = Time.time;
        currentState = newState;
    }

    public virtual void DoIdleState()
    {
        //IsWantsToGoFishing = true;
    }

    public virtual void DoTargetPlayer1State()
    {
        // If the GameManager exists
        if (GameManager.instance != null) 
        {
            // And the array of players exists
            if (GameManager.instance.players != null) 
            {
                // And there are players in it
                if (GameManager.instance.players.Count > 0) 
                {
                    //Then target the gameObject of the pawn of the first player controller in the list
                    AITarget = GameManager.instance.players[0].pawn.gameObject;
                }
            }
        }
    }

    public virtual GameObject GetNearestPlayer()
    {
        //assume that p1 is the closest
        GameObject nearestPlayer = GameManager.instance.players[0].pawn.gameObject;
        float nearestPlayerDistance = Vector3.Distance(pawn.transform.position, nearestPlayer.transform.position);

        //check to see if any other players are closer
        for (int index = 1; index <GameManager.instance.players.Count; index++)
        {
            float tempDistance = Vector3.Distance(pawn.transform.position, GameManager.instance.players[index].pawn.transform.position);
            if (tempDistance < nearestPlayerDistance)
            {
                //if the player we're looking at is closer, they are now the closest player.
                nearestPlayer = GameManager.instance.players[index].pawn.gameObject;
                nearestPlayerDistance = tempDistance;
            }
        }
        //silently prints a sheet of paper with the nearest player on it after several explosions from the printer
        return nearestPlayer;
    }

    public virtual void DoPatrolState()
    {
        Vector3 tempTargetLocation = waypoints[currentWaypoint].position;
        //Move to current waypoint
        tempTargetLocation = new Vector3(tempTargetLocation.x, pawn.transform.position.y, tempTargetLocation.z);
        Chase(tempTargetLocation);
        //once we reach the waypoint, move to the next
        if(Vector3.Distance(pawn.transform.position, tempTargetLocation) <= 1)
        {
            currentWaypoint++;
        }
        //once the last one is reached, move back to the first
        if(currentWaypoint >= waypoints.Count)
        {
            currentWaypoint = 0;
        }


    }

    public virtual void DoChangeTargetState()
    {
        AITarget = GetNearestPlayer();
    }

    public virtual void DoChaseState()
    {
        Chase(AITarget);
    }
    
    public virtual void DoFleeState()
    {
        Flee(AITarget);
    }

    public virtual void Flee(GameObject fleeTarget)
    {
        if(fleeTarget != null)
        {
            Flee(fleeTarget.transform.position);
        }
    }

    public virtual void Flee(Transform fleeTarget)
    {
        Flee(fleeTarget.gameObject);
    }

    public virtual void Flee(Controller fleeTarget)
    {
        Flee(fleeTarget.pawn.gameObject);
    }

    public virtual void Flee(Vector3 fleeTarget)
    {
        if (fleeTarget != null)
        {
            //turn away from the target
            pawn.TurnAway(fleeTarget);
            //gun it
            pawn.MoveForward();
        }
    }

    public virtual void Chase(GameObject chaseTarget)
    {
        if(chaseTarget != null)
        {
            Chase(chaseTarget.transform.position);
        }
        else
        {
            Debug.Log("Null Target");
        }
    }

    public virtual void Chase(Transform chaseTarget)
    {
        Chase(chaseTarget.gameObject);
    }

    public virtual void Chase(Controller chaseTarget)
    {
        Chase(chaseTarget.pawn.gameObject);
    }

    public virtual void Chase(Vector3 chaseTarget)
    {
        if (chaseTarget != null)
        {
            //Turn toward the target
            pawn.TurnTowards(chaseTarget);
            //FLOOR IT
            pawn.MoveForward();
        }
        else
        {
            Debug.Log("Null Target! :(");
        }
    }

    public virtual void DoTurnState()
    {
        TurnTowards(AITarget);
    }

    public virtual void DoTurnAwayState()
    {
        TurnAway(AITarget);
    }

    public virtual void TurnTowards(Controller target)
    {
        TurnTowards(target.pawn.gameObject);
    }

    public virtual void TurnTowards(GameObject target)
    {
        if (target != null)
        {
            TurnTowards(target.transform.position);
        }
    }

    public virtual void TurnTowards(Vector3 target)
    {
        pawn.TurnTowards(target);
    }

    public virtual void TurnAway(GameObject target)
    {
        if (target != null)
        {
            TurnTowards(target.transform.position);
        }
    }

    public virtual void TurnAway(Controller target)
    {
        TurnAway(target.pawn.gameObject);
    }

    public virtual void TurnAway(Vector3 target)
    {
        pawn.TurnAway(target);
    }

    public virtual void DoAttackState()
    {
        pawn.Shoot();
    }
    
    public virtual bool IsTimePassed(float amountOfTime)
    {
        if (Time.time - timeEnteredCurentState >= amountOfTime)
        {
            return true;
        }
        return false;
    }

   public bool IsCanHear(GameObject target)
    {
        // Get the target's Noisemaker
        Noisemaker noiseMaker = target.GetComponent<Noisemaker>();
        // If they don't have one, they can't make noise, so return false
        if (noiseMaker == null) 
        {
            return false;
        }
        // If they are making 0 noise, they also can't be heard
        if (noiseMaker.noiseDistance <= 0) 
        {
            return false;
        }
        // If they are making noise, add the volumeDistance in the noisemaker to the hearingDistance of this AI
        float totalDistance = noiseMaker.noiseDistance + hearingDistance;
        // If the distance between our pawn and target is closer than this...
        if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance) 
        {
            // ... then we can hear the target
            return true;
        }
        else 
        {
            // Otherwise, we are too far away to hear them
            return false;
        }
    }

}
