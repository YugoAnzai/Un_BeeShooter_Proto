using UnityEngine;
using UnityEngine.AI;

public class BeePulled : FsmState
{

    public override string StateName => "BeePulled";

    [SerializeField] private NavMeshAgent agent;

    public override void OnStateEnter()
    {
        agent.enabled = false;
    }

    public override void OnStateLeave()
    {
        agent.enabled = true;
    }

}