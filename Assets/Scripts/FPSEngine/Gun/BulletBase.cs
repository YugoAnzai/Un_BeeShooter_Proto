using System;
using UnityEngine;

[RequireComponent(typeof(CountdownCaller))]
public class BulletBase : MonoBehaviour
{

    public Action onHit;
    public Action onTimeout;
    public Action onForceKill;
    public Action onDie;

    protected Vector3 _velocity;
    protected bool _isMoving;

    protected virtual void Update()
    {

        if (_isMoving)
        {

            transform.Translate(_velocity * Time.deltaTime, Space.World);

        }

    }

    private void OnCollisionEnter(Collision other)
    {
        Hit(other.gameObject, other.GetContact(0).point);
    }

    private void OnTriggerEnter(Collider other)
    {
        Hit(other.gameObject, other.ClosestPoint(transform.position));
    }

    protected virtual void Hit(GameObject otherObj, Vector3 position)
    {

        onHit?.Invoke();

        Die();

    }

    protected virtual void OnTimeout()
    {

        onTimeout?.Invoke();

        Die();

    }

    public virtual void ForceKill()
    {

        onForceKill?.Invoke();

        Die();

    }

    public void SetVelocity(Vector3 velocity)
    {

        transform.forward = velocity;
        _velocity = velocity;
        _isMoving = true;

    }

    public void SetLifetime(float lifeTime)
    {

        GetComponent<CountdownCaller>().Countdown(
            lifeTime,
            OnTimeout
        );

    }

    protected virtual void Die()
    {
        _isMoving = false;
        Destroy(gameObject);
    }

}