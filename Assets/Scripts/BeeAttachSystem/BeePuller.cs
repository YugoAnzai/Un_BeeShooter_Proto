using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections;
using System;

public class BeePuller : BulletBase
{

    [SerializeField] private float pullForce = 10;

    [SerializeField] private float pullTime = 3;
    [SerializeField] private float pullRadius = 4;
    [SerializeField] private Color gizmoColor;
    [SerializeField] private LayerMask attachingBeeLayerMask;

    [SerializeField] private bool drawPulledBees = true;
    [SerializeField] private Color pulledBeesGizmoColor;

    private bool _isPulling;

    // Events
    public Action onStartPull;

    private List<AttachingBee> _bees;

    protected override void Update()
    {

        base.Update();

        PullUpdate();

    }

    protected override void AfterDieEffect()
    {

        GetComponent<Rigidbody>().isKinematic = true;

        StartPull();

    }

    private void PullUpdate()
    {

        if (!_isPulling)
            return;

        foreach(AttachingBee bee in _bees)
        {

            if (bee == null)
                return;
            
            bee.AddForceToAttachedAtPos(
                (transform.position - bee.transform.position)
                * pullForce * Time.deltaTime
            );
            
        }

    }

    [Button]
    public void StartPull()
    {

        if (_isPulling)
            return;

        _isPulling = true;
        
        if (_bees == null)
            _bees = new List<AttachingBee>();

        List<Collider> cols = Physics.OverlapSphere(
            transform.position,
            pullRadius, 
            attachingBeeLayerMask
        ).ToList();

        foreach(Collider col in cols)
        {
            var attachingBee = col.GetComponent<AttachingBee>();
            if (attachingBee != null)
            {
                _bees.Add(attachingBee);
            }
        }

        onStartPull?.Invoke();

        StartCoroutine(PullEndRoutine());

    }

    private IEnumerator PullEndRoutine()
    {
        yield return new WaitForSeconds(pullTime);
        EndPull();
    }

    public void EndPull()
    {

        _isPulling = false;
        _bees.Clear();

        Destroy(gameObject);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, pullRadius);

        if (drawPulledBees && _bees != null && _bees.Count > 0)
        {
            foreach(AttachingBee bee in _bees)
            {

                if (bee != null)
                {
                    Gizmos.color = pulledBeesGizmoColor;
                    Gizmos.DrawWireSphere(bee.transform.position, 0.3f);
                }
            }
        }

    }

}