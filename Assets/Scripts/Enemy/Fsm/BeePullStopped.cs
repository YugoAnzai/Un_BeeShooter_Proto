using UnityEngine;

public class BeePullStopped : FsmCondition
{

    [SerializeField] private BeeAttachable beeAttachable;

    private bool _stopped;

    private void Awake()
    {
        beeAttachable.onStopPull += OnPullStop;
    }

    private void OnPullStop()
    {
        _stopped = true;
    }

    public override bool IsSatisfied(FsmState curr, FsmState next)
    {

        if (_stopped)
        {
            _stopped = false;
            return true;
        }

        return false;

    }

}