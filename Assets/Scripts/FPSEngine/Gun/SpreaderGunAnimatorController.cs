using UnityEngine;

public class SpreaderGunAnimatorController : GunBaseAnimatorController
{
    
    [SerializeField] private string isShootingVarName;

    [SerializeField] private ParticleSystem dustParticles;

    private bool _wasShooting;

    private void Update()
    {
        
        animator.SetBool(isShootingVarName, _gunBase.IsShooting);

        if (_wasShooting ^ _gunBase.IsShooting)
        {
            if (_gunBase.IsShooting)
                dustParticles.Play();
            else
                dustParticles.Stop();
        }

        _wasShooting = _gunBase.IsShooting;

    }


}