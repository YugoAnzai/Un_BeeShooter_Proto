using UnityEngine;

public class TimedStateFinished : FsmCondition
{

    public override bool IsSatisfied(FsmState curr, FsmState next)
    {

        FsmTimedState timedSt = curr as FsmTimedState;
        if (timedSt == null)
            return false;
        
        return timedSt.CountdownFinished;

    }

}