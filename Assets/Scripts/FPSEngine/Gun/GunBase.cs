using System;
using UnityEngine;

public abstract class GunBase : MonoBehaviour
{

    public bool debug = true;

    [SerializeField] protected Transform muzzle;
    [SerializeField] protected GameObject visuals;

    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private float candencyDelay = 0.5f;
    [SerializeField] private float reloadTime = 1;

    private int _curAmmo;
    private bool _isReloading;
    private bool _isInCadency;
    private bool _isShooting;
    private bool _wasShooting;

    private float _candencyCounter;
    private float _reloadCounter;

    // Events
    public Action onEquipped;
    public Action onUnequipped;
    public Action onShot;
    public Action onReloadStart;
    public Action onReloaded;

    // Properties
    public int MaxAmmo => maxAmmo;
    public int CurAmmo => _curAmmo;
    public bool IsReloading => _isReloading;
    public float ReloadTime => reloadTime;
    public float ReloadCounter => _reloadCounter;
    public bool IsShooting => _isShooting;

    protected virtual void Awake()
    {
        _curAmmo = maxAmmo;
    }

    protected virtual void Update()
    {
        
        IsShootingUpdate();

        CadencyUpdate();
        ReloadUpdate();

        _wasShooting = _isShooting;
    }

    private void IsShootingUpdate()
    {

        if (!_isShooting)
            return;
        
        if (!_wasShooting)
        {
            Shoot();
        } else
        {
            if (!_isInCadency)
            {
                Shoot();
            }
        }

    }

    private void CadencyUpdate()
    {
        if (!_isInCadency)
            return;
        
        if ((_candencyCounter -= Time.deltaTime) < 0)
        {
            _isInCadency = false;
        }

    }

    private void ReloadUpdate()
    {

        if (!_isReloading)
            return;

        if ((_reloadCounter -= Time.deltaTime) < 0)
        {
            Reloaded();
        }

    }

    public virtual bool TryStartShoot()
    {

        if (
            _curAmmo <= 0 ||
            _isInCadency ||
            _isReloading ||
            _isShooting
        ) {
            return false;
        }

        StartShoot();

        return true;

    }

    protected virtual void StartShoot()
    {
        _isShooting = true;
    }

    protected virtual void Shoot()
    {

        if (_curAmmo <= 0)
        {
            EndShoot();
            return;
        }

        _curAmmo--;

        _candencyCounter = candencyDelay;
        _isInCadency = true;

        onShot?.Invoke();

        ShootEffect();

    }

    protected virtual void ShootEffect()
    {
        
    }

    public virtual void EndShoot()
    {

        _isShooting = false;

    }

    public virtual void Reload()
    {
        _isReloading = true;
        _reloadCounter = reloadTime;

        onReloadStart?.Invoke();

    }

    protected virtual void Reloaded()
    {
        _isReloading = false;
        _curAmmo = maxAmmo;

        onReloaded?.Invoke();

    }

    public void Equip()
    {
        onEquipped?.Invoke();
        visuals.gameObject.SetActive(true);
    }

    public void Unequip()
    {
        onUnequipped?.Invoke();
        visuals.gameObject.SetActive(false);
    }

}