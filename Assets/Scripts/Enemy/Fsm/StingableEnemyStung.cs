using UnityEngine;

public class StingableEnemyStung : FsmCondition
{

    [SerializeField] private StingTarget stingTarget;

    private bool stung;

    private void Awake()
    {
        stingTarget.onStung += OnStung;
    }

    private void OnStung()
    {
        stung = true;
    }

    public override bool IsSatisfied(FsmState curr, FsmState next)
    {
        if (stung)
        {
            stung = false;
            return true;
        }
        return false;
    }
}