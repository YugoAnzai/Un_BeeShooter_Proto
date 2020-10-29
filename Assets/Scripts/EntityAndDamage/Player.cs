using System;
using UnityEngine;

public class Player : Entity
{

    public Action onHeal;

    public override bool Damage(int damage, bool considerInvincibility = true)
    {
        bool ret = base.Damage(damage, considerInvincibility);
        if (ret) {
            // soundManager.Play("Hurt");
            // GetComponent<Animator>().SetTrigger("hit");
        }
        return ret;
    }

    protected override void Die()
    {
        base.Die();
        // GetComponent<Animator>().SetTrigger("die");
    }

    public virtual void Heal(int heal)
    {
        // AudioManager.Instance.Play("Heal");
        if (!isAlive) return;
        hp += heal;

        onHeal?.Invoke();
    }

}