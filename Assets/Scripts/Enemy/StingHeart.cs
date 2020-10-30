using UnityEngine;

public class StingHeart : StingTarget
{
    
    private bool _isAlive;

    public override void Stung()
    {
        base.Stung();
        
        _isAlive = false;

        Destroy(gameObject);
        
    }
    
}