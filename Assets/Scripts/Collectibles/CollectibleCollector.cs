using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollectibleCollector : OnTouchEffectBase
{

    protected override void Effect(GameObject gameObject)
    {
        ICollectible collectible = gameObject.GetComponent<ICollectible>();
        if (collectible != null)
        {
            collectible.Collect();
        }
    }

}