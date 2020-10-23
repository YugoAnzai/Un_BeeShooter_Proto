using UnityEngine;
using Sirenix.OdinInspector;

public class BeePullerGun : GunBase
{

    [AssetsOnly]
    
    [SerializeField] private GameObject pullerPrefab;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private float pullerLifetime = 3;

    private BeePuller _curPuller;

    protected override void ShootEffect()
    {

        GameObject puller = Instantiate(pullerPrefab, muzzle.position, Quaternion.identity);

        _curPuller = puller.GetComponent<BeePuller>();

        Debug.DrawRay(muzzle.position, muzzle.forward * bulletSpeed, 
            Color.yellow,0.2f);

        _curPuller.SetVelocity(muzzle.forward * bulletSpeed);
        _curPuller.SetLifetime(pullerLifetime);

    }

}