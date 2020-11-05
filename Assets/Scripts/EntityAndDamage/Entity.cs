using System;
using UnityEngine;
using Sirenix.OdinInspector;

public class Entity : MonoBehaviour, IDamageable
{
    
    public int totalHp = 1;
    public float invincibilityTime = 0.5f;

    [HideInInspector]
    protected int hp;

    protected bool isAlive;

    protected bool isInvincible = false;

    public bool IsAlive { get => isAlive; }
    public int Hp { get => hp; }

    public Action<Entity> onDie;
    public Action<int> onDamagePassHp;

    protected virtual void Awake()
    {
        Setup();
    }

    protected virtual void Setup()
    {
        hp = totalHp;
        isAlive = true;
    }

    [Button]
    public virtual bool Damage(int damage, bool considerInvincibility = true)
    {
        
        if (!isAlive) return false;
        if (isInvincible && considerInvincibility) return false;

        hp -= damage;
        
        if (hp < 0)
            hp = 0;

        if(hp <= 0) {
            Die();
        } else {
            MakeInvincible(invincibilityTime);
        }

        onDamagePassHp?.Invoke(hp);

        return true;
    }

    protected virtual void Die()
    {
        isAlive = false;
        onDie?.Invoke(this);
    }

    public void ForceKill()
    {
        Die();
    }

    public void ForceRevive()
    {
        Setup();
    }

    public void MakeInvincible(float time)
    {
        MakeInvincible();
        Invoke(nameof(MakeVincible), time);
    }

    public void MakeInvincible()
    {
        isInvincible = true;
    }

    public void MakeVincible()
    {
        isInvincible = false;
    }

}