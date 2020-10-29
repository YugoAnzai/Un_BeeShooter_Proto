using UnityEngine;
using YugoA.Helpers;

[RequireComponent(typeof(Collider))]
public abstract class OnTouchEffectBase : MonoBehaviour
{

    protected virtual void OnTriggerEnter(Collider other)
    {
        LogHelper.Log("Trigger Enter", Color.blue);
        Effect(other.gameObject);
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        LogHelper.Log("Collision Enter", Color.blue);
        Effect(other.gameObject);
    }

    protected abstract void Effect(GameObject obj);

}