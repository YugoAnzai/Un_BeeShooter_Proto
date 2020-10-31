using UnityEngine;
using YugoA.Helpers;

public class StingGun : GunBase
{

    public bool debug = true;

    [SerializeField] private float range = 50;
    [SerializeField] LayerMask layerMask;

    protected override void ShootEffect()
    {
        
        Vector3 dir = muzzle.forward;

        if (debug)
            Debug.DrawRay(muzzle.position, dir * range, Color.red, .4f);

        RaycastHit hit;
        if (Physics.Raycast(muzzle.position, muzzle.forward, out hit, range, layerMask))
        {

            if (debug)
                LogHelper.Log($"StingGun Hit: {hit.collider.gameObject.name}", Color.cyan);
            
            StingTarget target = hit.collider.GetComponent<StingTarget>();
            if (target != null)
            {
                target.Stung();
            }
            
        }

    }

}