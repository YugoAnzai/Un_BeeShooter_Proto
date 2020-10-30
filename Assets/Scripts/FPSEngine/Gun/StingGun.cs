using UnityEngine;

public class StingGun : GunBase
{

    [SerializeField] private float range = 50;
    [SerializeField] LayerMask layerMask;

    protected override void ShootEffect()
    {
        
        Vector3 dir = muzzle.forward;
        Debug.DrawRay(muzzle.position, dir * range, Color.red, .4f);

        RaycastHit hit;
        if (Physics.Raycast(muzzle.position, muzzle.forward, out hit, range, layerMask))
        {

            YugoA.Helpers.LogHelper.Log($"StingGun Hit: {hit.collider.gameObject.name}", Color.red);
            StingTarget target = hit.collider.GetComponent<StingTarget>();
            if (target != null)
            {
                target.Stung();
            }
            
        }

    }

}