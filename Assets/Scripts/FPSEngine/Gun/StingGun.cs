using UnityEngine;
using YugoA.Helpers;
using Sirenix.OdinInspector;

public class StingGun : GunBase
{

    [SerializeField] private float range = 50;
    [SerializeField] LayerMask layerMask;

    [SerializeField] private Transform visualLineMuzzle;
    [AssetsOnly]
    [SerializeField] private GameObject linePrefab;

    protected override void ShootEffect()
    {
        
        Vector3 dir = muzzle.forward;

        bool hadHit = false;
        RaycastHit hit;
        if (Physics.Raycast(muzzle.position, muzzle.forward, out hit, range, layerMask))
        {

            hadHit = true;

            if (debug)
                LogHelper.Log($"StingGun Hit: {hit.collider.gameObject.name}", Color.cyan);
            
            StingTarget[] targets = hit.collider.GetComponents<StingTarget>();
            foreach(StingTarget target in targets)
            {
                target.Stung();
            }
            
        }

        if (hadHit)
        {
            CreateLineEffect(visualLineMuzzle.position, hit.point);
        } else
        {
            CreateLineEffect(visualLineMuzzle.position, visualLineMuzzle.position + dir * range);
        }

    }

    private void CreateLineEffect(Vector3 startPos, Vector3 endPos)
    {

        GameObject line = Instantiate(linePrefab);
        LineRenderer renderer = line.GetComponent<LineRenderer>();

        if (renderer != null)
        {
            renderer.enabled = true;
            renderer.SetPosition(0,startPos);
            renderer.SetPosition(1,endPos);
        }

    }

}