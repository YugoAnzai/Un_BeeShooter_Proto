using System;
using UnityEngine;
using YugoA.Helpers;

[RequireComponent(typeof(Rigidbody))]
public class BeeAttachable : MonoBehaviour
{
    
    [SerializeField] private Transform beesHolder;
    [SerializeField] private float checkPullInterval = .5f;

    public bool debug = false;
    public Color debugLogColor = Color.yellow;

    private bool _pulledThisFrame;

    private bool _isBeingPulled;

    private Rigidbody _rb;
    private float _checkPullCounter;
    private bool _wasBeingPulled = false;
    private bool _initialIsKinematic;

    // Events
    public Action onStartPull;
    public Action onStopPull;

    // Properties
    public bool IsBeingPulled => _isBeingPulled;

    public Rigidbody Rb {
        get {
            if (_rb == null)
                _rb = GetComponent<Rigidbody>();
            
            return _rb;
        }
    }

    public Transform GetBeeHolder() => 
        beesHolder != null ? beesHolder : transform;

    private void Awake()
    {
        _initialIsKinematic = Rb.isKinematic;
    }

    private void Update()
    {

        if (_pulledThisFrame)
        {
            _isBeingPulled = true;
            _checkPullCounter = checkPullInterval;
            _pulledThisFrame = false;
        }
        
        if (_checkPullCounter < 0)
        {
            _isBeingPulled = false;
        } else
        {
            _checkPullCounter -= Time.deltaTime;
        }

        if (_wasBeingPulled ^ _isBeingPulled)
        {
            if (_isBeingPulled)
                OnStartPull();
            else
                OnStopPull();
        }

        _wasBeingPulled = _isBeingPulled;

    }

    public void SetPulledThisFrame()
    {
        _pulledThisFrame = true;
    }

    private void OnStartPull()
    {
        if (debug) LogHelper.Log($"Start Pull {gameObject.name}", debugLogColor);

        if (Rb.isKinematic)
            Rb.isKinematic = false;
        
        onStartPull?.Invoke();
    }

    private void OnStopPull()
    {
        if (debug) LogHelper.Log($"Stop Pull {gameObject.name}", debugLogColor);

        Rb.isKinematic = _initialIsKinematic;

        onStopPull?.Invoke();
    }

}