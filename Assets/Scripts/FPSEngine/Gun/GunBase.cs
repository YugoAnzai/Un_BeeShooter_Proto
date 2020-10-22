using UnityEngine;

public abstract class GunBase : MonoBehaviour
{

    [SerializeField] protected Transform muzzle;

    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private float candencyDelay = 0.5f;
    [SerializeField] private float reloadDelay = 1;

    private int _curAmmo;
    private bool _isReloading;
    private bool _isShooting;
    private bool _wasShooting;

    private float _candencyCounter;
    private float _reloadCounter;

    public int MaxAmmo => maxAmmo;

    protected virtual void Awake()
    {
        _curAmmo = maxAmmo;
    }

    protected virtual void Update()
    {
        
        IsShootingUpdate();

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
            if (_candencyCounter < 0)
            {
                Shoot();
            } else
            {
                _candencyCounter -= Time.deltaTime;
            }
        }

    }

    private void ReloadUpdate()
    {

        if (!_isReloading)
            return;

        if (_reloadCounter < 0)
        {
            Reloaded();
        } else 
        {
            _reloadCounter -= Time.deltaTime;
        }

    }

    public virtual bool TryStartShoot()
    {

        if (_curAmmo <= 0)
            return false;

        if (_isReloading)
            return false;

        if (_isShooting)
            return false;

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
        ShootEffect();

    }

    protected abstract void ShootEffect();

    public virtual void EndShoot()
    {

        _isShooting = false;

    }

    public virtual void Reload()
    {
        _isReloading = true;
        _reloadCounter = reloadDelay;
    }

    protected virtual void Reloaded()
    {
        _isReloading = false;
        _curAmmo = maxAmmo;
    }

}