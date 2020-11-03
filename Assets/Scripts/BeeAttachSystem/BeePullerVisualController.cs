using UnityEngine;

[RequireComponent(typeof(BeePuller))]
public class BeePullerVisualController : MonoBehaviour
{
    
    [SerializeField] private Transform rotateTarget;
    [SerializeField] float rotateSpeed = 1;

    private BeePuller _beePuller;
    private Vector3 _rotation;

    private void Awake()
    {
        _beePuller = GetComponent<BeePuller>();
        _beePuller.onStartPull += OnStartPull;

        StartRotation();

    }

    private void Update()
    {
        RotateUpdate();
    }

    private void OnStartPull()
    {
        StopRotation();
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