using System;
using UnityEngine;

public class CountdownCaller : MonoBehaviour
{

    private Action _callback;
    private float _counter;
    private bool _isCounting;

    private void Update()
    {
        
        if (!_isCounting)
            return;

        if (_counter < 0)
        {
            _callback?.Invoke();
            _callback = null;
            _isCounting = false;
        } else 
        {
            _counter -= Time.deltaTime;
        }

    }

    public void Countdown(float time, Action callback)
    {
        _counter = time;
        _callback = callback;
        _isCounting = true;
    }

}