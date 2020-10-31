using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoHUDController : MonoBehaviour
{

    [SerializeField] private GunBase _gun;

    [Header("UI")]
    [SerializeField] private GameObject parent;
    [SerializeField] private TextMeshProUGUI ammoCounter;
    [SerializeField] private Image ammoBg;
    [SerializeField] private Image fill;

    private bool _wasReloading;

    private void Awake()
    {
        _gun.onEquipped += OnEquipped;
        _gun.onUnequipped += OnUnequipped;
    }

    private void OnDestroy()
    {
        _gun.onEquipped -= OnEquipped;
        _gun.onUnequipped -= OnUnequipped;
    }

    protected virtual void Update()
    {
        
        ammoCounter.text = _gun.CurAmmo.ToString();

        fill.fillAmount = GetFillPercentage(_gun);

    }

    protected float GetFillPercentage(GunBase gun)
    {
        if (!gun.IsReloading)
        {
            return (float) gun.CurAmmo /  gun.MaxAmmo;
        } else
        {
            return 1 - (gun.ReloadCounter / gun.ReloadTime);
        }
    }

    protected virtual void OnEquipped()
    {
        parent.gameObject.SetActive(true);
    }

    protected virtual void OnUnequipped()
    {
        parent.gameObject.SetActive(false);
    }

}