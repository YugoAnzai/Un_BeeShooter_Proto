using System.Collections;
using UnityEngine;

public class FsmTimedState : FsmState
{
    
    public override string StateName => "FsmTimedState";

    public float duration;
    
    private bool _countdownFinished;
    private Coroutine _countdownRoutine;

    public bool CountdownFinished => _countdownFinished;

    public override void OnStateEnter()
    {
        _countdownFinished = false;
        _countdownRoutine = StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        yield return new WaitForSeconds(duration);
        _countdownFinished = true;
    }

}