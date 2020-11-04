using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(ParticleSystem))]
public class BeeSpreaderParticleController : MonoBehaviour
{

    [AssetsOnly]
    [SerializeField] private GameObject beePrefab;
    [SerializeField] float beeLifetime = 10;

    private ParticleSystem _particleSyst;
    private List<ParticleCollisionEvent> _collisionEvents;

    private void Awake()
    {
        _particleSyst = GetComponent<ParticleSystem>();
        _collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {

        var beeAttachable = other.GetComponent<BeeAttachable>();
        if (beeAttachable == null)
            return;
        
        _particleSyst.GetCollisionEvents(other, _collisionEvents);

        foreach(ParticleCollisionEvent colEvent in _collisionEvents)
        {

            AttachingBee bee = CreateAttachingBee(
                colEvent.intersection,
                colEvent.normal,
                beeAttachable.GetBeeHolder()
            );

            bee.AttachTo(beeAttachable);
            bee.MakeAliveForLifetime(beeLifetime);

        }

    }

    private AttachingBee CreateAttachingBee(Vector3 position, Vector3 normal, Transform beeParent)
    {

        GameObject obj = Instantiate(beePrefab, position, Quaternion.identity);

        obj.transform.forward = - normal;
        obj.transform.parent = beeParent;

        return obj.GetComponent<AttachingBee>();

    }

}