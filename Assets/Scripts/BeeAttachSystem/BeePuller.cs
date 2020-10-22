using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;

public class BeePuller : MonoBehaviour
{

    [SerializeField] private float pullForce = 10;

    [SerializeField] private float pullTime = 3;
    [SerializeField] private float pullRadius = 4;
    [SerializeField] private Color gizmoColor;
    [SerializeField] private LayerMask attachingBeeLayerMask;

    [SerializeField] private bool drawPulledBees = true;
    [SerializeField] private Color pulledBeesGizmoColor;

    private float _pullCounter;
    private bool _isPulling;

    private List<AttachingBee> _bees;

    private void Update()
    {
        
        PullUpdate();

    }

    private void PullUpdate()
    {

        if (! _isPulling)
            return;

        foreach(AttachingBee bee in _bees)
        {
            bee.AddForceToAttachedAtPos(
                (transform.position - bee.transform.position)
                * pullForce * Time.deltaTime
            );
        }

        if (_pullCounter < 0)
        {
            EndPull();
        } else
        {
            _pullCounter -= Time.deltaTime;
        }

    }

    [Button]
    public void StartPull()
    {

        _isPulling = true;
        _pullCounter = pullTime;
        
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

    }

    public void EndPull()
    {
        _isPulling = false;
        _bees.Clear();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, pullRadius);

        if (drawPulledBees && _bees != null && _bees.Count > 0)
        {
            foreach(AttachingBee bee in _bees)
            {
                Gizmos.color = pulledBeesGizmoColor;
                Gizmos.DrawWireSphere(bee.transform.position, 0.3f);
            }
        }


    }

}