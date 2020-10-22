using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(ParticleSystem))]
public class BeeSpreaderParticleController : MonoBehaviour
{

    [AssetsOnly]
    [SerializeField] private GameObject beePrefab;

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
            CreateAttachingBee(
                colEvent.intersection,
                colEvent.normal,
                beeAttachable.GetBeeHolder()
            );
        }

    }

    private AttachingBee CreateAttachingBee(Vector3 position, Vector3 normal, Transform parent)
    {

        GameObject obj = Instantiate(beePrefab, position, Quaternion.identity, parent);

        obj.transform.forward = - normal;

        return obj.GetComponent<AttachingBee>();

    }

}