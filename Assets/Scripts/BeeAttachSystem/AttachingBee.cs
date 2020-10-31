using UnityEngine;

[RequireComponent(typeof(CountdownCaller))]
public class AttachingBee : MonoBehaviour
{
    
    private BeeAttachable _beeAttachable;

    public void AttachTo(BeeAttachable beeAttachable)
    {
        _beeAttachable = beeAttachable;
    }

    public void MakeAliveForLifetime(float lifeTime)
    {

        GetComponent<CountdownCaller>().Countdown(
            lifeTime,
            Die
        );

    }

    public void AddForceToAttachedAtPos(Vector3 force)
    {

        if (_beeAttachable == null)
            return;

        _beeAttachable.SetPulledThisFrame();
        _beeAttachable.Rb.AddForceAtPosition(force, transform.position, ForceMode.Force);

    }

    private void Die()
    {
        Destroy(gameObject);
    }

}