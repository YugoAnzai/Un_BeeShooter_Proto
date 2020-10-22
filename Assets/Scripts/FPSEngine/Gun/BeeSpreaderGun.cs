using UnityEngine;

public class BeeSpreaderGun : GunBase
{

    [SerializeField] private ParticleSystem beeSpreaderParticle;

    [SerializeField] private GameObject beePrefab;

    protected override void StartShoot()
    {

        base.StartShoot();

        

    }

    protected override void ShootEffect()
    {
        
        beeSpreaderParticle.Emit(1);

    }

    public override void EndShoot()
    {

        base.EndShoot();



    }

}