using UnityEngine;
using YugoA.Helpers;

[RequireComponent(typeof(Collider))]
public abstract class OnTouchEffectBase : MonoBehaviour
{

    public bool debug = false;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (debug) LogHelper.Log("Trigger Enter", Color.blue);
        Effect(other.gameObject);
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        if (debug) LogHelper.Log("Collision Enter", Color.blue);
        Effect(other.gameObject);
    }

    protected abstract void Effect(GameObject obj);

}