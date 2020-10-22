using System.Collections.Generic;
using UnityEngine;

public class GunOperator : MonoBehaviour
{

    public List<GunBase> guns;

    private GunBase _equippedGun;

    private void Start()
    {
        if (guns.Count > 0)
            EquipGun(guns[0]);
    }

    private void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            _equippedGun.TryStartShoot();
        } else if (Input.GetButtonUp("Fire1"))
        {
            _equippedGun.EndShoot();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            _equippedGun.Reload();
        }

    }

    private void EquipGun(GunBase gun)
    {
        _equippedGun = gun;
    }

}