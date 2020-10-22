using UnityEngine;

public class BeeSpreaderGun : GunBase
{

    [SerializeField] private ParticleSystem beeSpreaderParticle;

    protected override void ShootEffect()
    {
        
        beeSpreaderParticle.Emit(1);

    }

}