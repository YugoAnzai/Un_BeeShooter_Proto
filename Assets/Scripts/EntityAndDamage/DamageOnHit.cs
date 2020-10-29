using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DamageOnHit : OnTouchEffectBase {
    
    public int damage = 1;

    protected override void Effect(GameObject gameObject) {
        IDamageable damageable = gameObject.GetComponent<IDamageable>();
        if (damageable!= null) {
            damageable.Damage(damage);
        }
    }

}