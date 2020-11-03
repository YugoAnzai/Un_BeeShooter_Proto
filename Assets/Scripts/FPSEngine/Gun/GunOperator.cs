using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunOperator : MonoBehaviour
{

    public List<GunBase> guns;

    [SerializeField] private float changeDisableDelay = .2f;

    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private string changeGunTrigger;

    private GunBase _equippedGun;
    private int _gunIndex;

    private bool changeDisabled = false;
    private AnimatorHelper _animHelper;

    private GunBase _gunToEquipMemory;

    public GunBase EquippedGun => _equippedGun;

    private void Awake()
    {
        _animHelper = animator.GetComponent<AnimatorHelper>();
    }

    private void Start()
    {

        foreach(GunBase gun in guns)
        {
            gun.Unequip();
        }

        _gunIndex = 0;

        StartEquipGun(guns[_gunIndex]);

    }

    private void Update()
    {

        ActionsUpdate();

    }

    private void ActionsUpdate()
    {

        if (changeDisabled)
            return;

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

        StartEquipGun(guns[_gunIndex]);

    }

    private void StartEquipGun(GunBase gun)
    {

        _gunToEquipMemory = gun;
        _animHelper.action += EquipGunFromMemory;
        AnimateGunChange();

        changeDisabled = true;
        StartCoroutine(ChangeDisabledRestoreRoutine());

    }

    private void EquipGunFromMemory()
    {

        if (_equippedGun != null)
            _equippedGun.Unequip();

        _equippedGun = _gunToEquipMemory;
        _equippedGun.Equip();

        _gunToEquipMemory = null;

    }

    IEnumerator ChangeDisabledRestoreRoutine()
    {
        yield return new WaitForSeconds(changeDisableDelay);
        changeDisabled = false;
    }

    private void AnimateGunChange()
    {
        animator.SetTrigger(changeGunTrigger);
    }

}