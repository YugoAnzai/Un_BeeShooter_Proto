using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Entity))]
public class EntityEventOnReachHP : MonoBehaviour
{

    public int eventHP;
    public UnityEvent callback;

    private void Awake()
    {
        GetComponent<Entity>().onDamagePassHp += OnDamage;
    }

    private void OnDamage(int hp)
    {
        if (hp == eventHP)
        {
            callback?.Invoke();
        }
    }


}