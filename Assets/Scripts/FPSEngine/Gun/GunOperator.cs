using System.Collections.Generic;
using UnityEngine;

public class GunOperator : MonoBehaviour
{

    public List<GunBase> guns;

    private GunBase _equippedGun;
    private int _gunIndex;

    private void Start()
    {

        _gunIndex = 0;

        EquipGun(guns[_gunIndex]);

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

        if (Input.GetButtonDown("Fire3"))
        {
            EquipNextGun();
        }

    }

    private void EquipNextGun()
    {

        _gunIndex++;
        if (_gunIndex >= guns.Count)
        {
            _gunIndex = 0;
        }

        EquipGun(guns[_gunIndex]);

    }

    private void EquipGun(GunBase gun)
    {

        if (_equippedGun != null)
            _equippedGun.gameObject.SetActive(false);

        _equippedGun = gun;
        _equippedGun.gameObject.SetActive(true);

    }

}