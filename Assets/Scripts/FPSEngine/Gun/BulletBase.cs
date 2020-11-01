using System;
using UnityEngine;
using YugoA.Helpers;

[RequireComponent(typeof(CountdownCaller))]
public class BulletBase : MonoBehaviour
{

    public bool debug = true;

    public Action onHit;
    public Action onTimeout;
    public Action onForceKill;
    public Action onDie;

    protected Vector3 _velocity;
    protected bool _isMoving;

    protected bool _isAlive;

    protected virtual void Update()
    {

        if (_isMoving && _isAlive)
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

        if (debug) LogHelper.Log($"Bullet Hit Start: {otherObj.name} in {position}", Color.blue);

        if(!_isAlive)
            return;

        if(!IsValidTarget(otherObj))
            return;

        if (debug) LogHelper.Log($"Bullet Hit Confirm: {otherObj.name}", Color.blue);

        onHit?.Invoke();

        Die();

    }

    protected virtual bool IsValidTarget(GameObject hitObj)
    {
        return true;
    }

    protected virtual void OnTimeout()
    {

        if(!_isAlive)
            return;

        onTimeout?.Invoke();

        Die();

    }

    public virtual void ForceKill()
    {

        if(!_isAlive)
            return;

        onForceKill?.Invoke();

        Die();

    }

    public void StartupBullet(Vector3 velocity, float lifeTime)
    {

        _isAlive = true;

        SetVelocity(velocity);
        SetLifetime(lifeTime);

    }

    private void SetVelocity(Vector3 velocity)
    {

        transform.forward = velocity;
        _velocity = velocity;
        _isMoving = true;

    }

    private void SetLifetime(float lifeTime)
    {

        GetComponent<CountdownCaller>().Countdown(
            lifeTime,
            OnTimeout
        );

    }

    protected virtual void Die()
    {

        _isMoving = false;
        _isAlive = false;

        onDie?.Invoke();

        AfterDieEffect();

    }

    protected virtual void AfterDieEffect()
    {

        Destroy(gameObject);
        
    }

}