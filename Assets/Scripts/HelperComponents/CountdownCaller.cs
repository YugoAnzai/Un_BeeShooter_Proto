using System;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class CountdownCaller : MonoBehaviour
{

    [FoldoutGroup("Component Usage")]
    public bool useAsComponent = false;
    [FoldoutGroup("Component Usage")] [ShowIf(nameof(useAsComponent))]
    public bool startOnAwake;
    [FoldoutGroup("Component Usage")] [ShowIf(nameof(useAsComponent))]
    public float componentCountdown;
    [FoldoutGroup("Component Usage")] [ShowIf(nameof(useAsComponent))]
    public UnityEvent unityEvent;

    private Action _callback;
    private float _counter;
    private bool _isCounting;

    private void Awake()
    {
        if (useAsComponent && startOnAwake)
        {
            Countdown(componentCountdown);
        }
    }

    private void Update()
    {
        
        if (!_isCounting)
            return;

        if (_counter < 0)
        {
            CountdownFinished();
        } else 
        {
            _counter -= Time.deltaTime;
        }

    }

    public void Countdown(float time, Action callback = null)
    {

        _counter = time;
        _callback = callback;
        _isCounting = true;

    }

    private void CountdownFinished()
    {
        if(useAsComponent)
            unityEvent?.Invoke();
        _callback?.Invoke();

        _callback = null;
        _isCounting = false;
    }

}