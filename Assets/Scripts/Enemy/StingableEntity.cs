using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

public class StingableEntity : MonoBehaviour
{

    [SerializeField]
    private List<StingTarget> _stingableTargets;

    private int _targetQuantity;
    private int _stungTargetQuantity;

    private bool _isAlive = true;

    private void Awake()
    {
        SetupStingableTargets();
    }

    [Button]
    public void FindStingableTargets()
    {
        _stingableTargets = GetComponentsInChildren<StingTarget>().ToList();
    }

    private void SetupStingableTargets()
    {

        _targetQuantity = 0;
        foreach(StingTarget target in _stingableTargets)
        {
            target.onStung += OnTargetStung;
            _targetQuantity++;
        }

    }

    private void OnTargetStung()
    {

        _stungTargetQuantity++;

        if (_stungTargetQuantity == _targetQuantity)
        {
            Die();
        }

    }

    private void Die()
    {
        _isAlive = false;
        Destroy(gameObject);
    }

}