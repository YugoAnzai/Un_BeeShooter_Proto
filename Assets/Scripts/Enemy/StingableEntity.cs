using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

public class StingableEntity : Entity
{

    [SerializeField]
    private List<StingTarget> _stingableTargets;

    private int _targetQuantity;
    private int _stungTargetQuantity;

    protected override void Awake()
    {
        SetupStingableTargets();
        base.Awake();
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

        totalHp = _targetQuantity;

    }

    private void OnTargetStung()
    {

        Damage(1, false);

    }

    protected override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }

}