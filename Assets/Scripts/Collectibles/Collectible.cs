using UnityEngine;
using UnityEngine.Events;

public abstract class Collectible : MonoBehaviour, ICollectible
{

    protected bool _isCollected = false;

    public UnityEvent onCollect;

    public bool IsCollected => _isCollected;

    public virtual bool Collect()
    {
        if (!_isCollected)
        {
            Effect();
            _isCollected = true;
            onCollect?.Invoke();
            AfterEffect();
            return true;
        }
        return false;
    }

    protected abstract void Effect();

    protected virtual void AfterEffect()
    {
        gameObject.SetActive(false);
    }

    protected virtual void ResetCollectible()
    {
        _isCollected = false;
    }

}