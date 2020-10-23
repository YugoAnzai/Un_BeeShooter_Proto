using UnityEngine;

[RequireComponent(typeof(CountdownCaller))]
public class AttachingBee : MonoBehaviour
{
    
    private Rigidbody _attachedRb;

    public void AttachToRigidBody(Rigidbody rb)
    {
        _attachedRb = rb;
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

        if (_attachedRb == null)
            return;

        _attachedRb.AddForceAtPosition(force, transform.position, ForceMode.Force);

    }

    private void Die()
    {
        Destroy(gameObject);
    }

}