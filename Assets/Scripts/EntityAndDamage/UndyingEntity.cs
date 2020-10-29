using UnityEngine;

public class UndyingEntity : Entity
{
    
    public override bool Damage(int damage, bool considerInvincibility = true) {
        return true;
    }

}