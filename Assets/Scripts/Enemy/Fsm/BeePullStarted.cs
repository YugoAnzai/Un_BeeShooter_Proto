using UnityEngine;

public class BeePullStarted : FsmCondition
{

    [SerializeField] private BeeAttachable beeAttachable;

    private bool _started;

    private void Awake()
    {
        beeAttachable.onStartPull += OnPullStart;
    }

    private void OnPullStart()
    {
        _started = true;
    }

    public override bool IsSatisfied(FsmState curr, FsmState next)
    {

        if (_started)
        {
            _started = false;
            return true;
        }

        return false;

    }

}