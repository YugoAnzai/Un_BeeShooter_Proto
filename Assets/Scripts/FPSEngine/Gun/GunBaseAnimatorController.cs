using UnityEngine;

[RequireComponent(typeof(GunBase))]
public class GunBaseAnimatorController : MonoBehaviour
{
    
    [SerializeField] private Animator animator;

    [SerializeField] public string shotTrigger;
    [SerializeField] public string reloadStartTrigger;
    [SerializeField] public string reloadedTrigger;

    private GunBase _gunBase;

    private void Awake()
    {

        _gunBase = GetComponent<GunBase>();

        _gunBase.onShot += OnShot;
        _gunBase.onReloadStart += OnReloadStart;
        _gunBase.onReloaded += OnReloaded;

    }

    private void OnShot()
    {
        animator.SetTrigger(shotTrigger);
    }

    private void OnReloadStart()
    {
        animator.SetTrigger(reloadStartTrigger);
    }

    private void OnReloaded()
    {
        animator.SetTrigger(reloadedTrigger);
    }


    private void OnDestroy()
    {
        _gunBase.onShot -= OnShot;
        _gunBase.onReloadStart -= OnReloadStart;
        _gunBase.onReloaded -= OnReloaded;
    }

}