using UnityEngine;
using Sirenix.OdinInspector;

public class BeePullerGun : GunBase
{

    [AssetsOnly]
    
    [SerializeField] private GameObject pullerPrefab;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private float pullerLifetime = 3;

    private BeePuller _curPuller;

    public override bool TryStartShoot()
    {

        if (_curPuller != null)
        {
            _curPuller.ForceKill();
            return true;
        } else
        {
            return base.TryStartShoot();
        }
        
    }

    protected override void ShootEffect()
    {

        GameObject puller = Instantiate(pullerPrefab, muzzle.position, Quaternion.identity);

        _curPuller = puller.GetComponent<BeePuller>();

        Debug.DrawRay(muzzle.position, muzzle.forward * bulletSpeed, 
            Color.yellow,0.2f);

        _curPuller.StartupBullet(
            muzzle.forward * bulletSpeed,
            pullerLifetime
        );

        _curPuller.onDie += OnPullerDie;

    }

    private void OnPullerDie()
    {
        _curPuller = null;
    }

}