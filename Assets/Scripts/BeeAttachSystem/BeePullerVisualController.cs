using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

[RequireComponent(typeof(BeePuller))]
public class BeePullerVisualController : MonoBehaviour
{
    
    [Header("Rotate")]
    [SerializeField] private Transform rotateTarget;
    [SerializeField] float rotateSpeed = 1;

    [Header("Shake")]
    [SerializeField] private Transform shakeTarget;
    [SerializeField] private float shakeDuration = 5;
    [SerializeField] private float shakeStrength = 1;
    [SerializeField] private int shakeVibrato = 10;
    [SerializeField] private float shakeRandomness = 90;

    [Header("Particles")]
    [AssetsOnly]
    [SerializeField] private GameObject popParticlesPrefab;

    private BeePuller _beePuller;
    private Vector3 _rotation;

    private void Awake()
    {
        _beePuller = GetComponent<BeePuller>();
        _beePuller.onStartPull += OnStartPull;
        _beePuller.onEndPull += OnEndPull;

        StartRotation();

    }

    private void OnEndPull()
    {
        Instantiate(popParticlesPrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        RotateUpdate();
    }

    private void OnStartPull()
    {
        StopRotation();
        StartShake();
    }

    private void StartShake()
    {
        shakeTarget.DOShakePosition(
            shakeDuration,
            shakeStrength,
            shakeVibrato,
            shakeRandomness
        );
    }

    private void StartRotation()
    {

        Vector3 rand = new Vector3
        (
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;

        _rotation = rand * rotateSpeed;

    }

    private void RotateUpdate()
    {
        
        rotateTarget.Rotate(_rotation * Time.deltaTime, Space.World);

    }

    private void StopRotation()
    {

        _rotation = Vector3.zero;

    }

}