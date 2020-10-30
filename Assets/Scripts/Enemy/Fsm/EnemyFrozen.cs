using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFrozen : FsmTimedState
{
    
    public override string StateName => "EnemyFrozen";
    
    [SerializeField] private NavMeshAgent agent;

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        agent.isStopped = true;
    }

    public override void OnStateLeave()
    {
        agent.isStopped = false;
    }


}