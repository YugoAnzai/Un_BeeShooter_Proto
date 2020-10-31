using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFrozen : FsmTimedState
{
    
    public override string StateName => "EnemyFrozen";
    
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Rigidbody rb;

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        agent.isStopped = true;
        agent.enabled = false;
        rb.isKinematic = false;
    }

    public override void OnStateLeave()
    {
        agent.enabled = true;
        agent.isStopped = false;
        rb.isKinematic = true;
    }


}