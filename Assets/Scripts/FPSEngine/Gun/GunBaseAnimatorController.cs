using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GunBase))]
public class GunBaseAnimatorController : MonoBehaviour
{
    
    [SerializeField] private Animator animator;

    [Header("Triggers")]
    [SerializeField] public string shotTrigger;
    [SerializeField] public string reloadStartTrigger;
    [SerializeField] public string reloadedTrigger;

    [Header("Events")]
    public UnityEvent onShot;
    public UnityEvent onReloadStart;
    public UnityEvent onReloaded;


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
        onShot?.Invoke();
    }

    private void OnReloadStart()
    {
        animator.SetTrigger(reloadStartTrigger);
        onReloadStart?.Invoke();
    }

    private void OnReloaded()
    {
        animator.SetTrigger(reloadedTrigger);
        onReloaded?.Invoke();
    }

    private void OnDestroy()
    {
        _gunBase.onShot -= OnShot;
        _gunBase.onReloadStart -= OnReloadStart;
        _gunBase.onReloaded -= OnReloaded;
    }

}