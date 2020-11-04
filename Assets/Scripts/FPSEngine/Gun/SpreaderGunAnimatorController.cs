using UnityEngine;

public class SpreaderGunAnimatorController : GunBaseAnimatorController
{
    
    [SerializeField] private string isShootingVarName;

    private void Update()
    {
        animator.SetBool(isShootingVarName, _gunBase.IsShooting);
    }


}