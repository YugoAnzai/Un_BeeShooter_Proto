using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BeeAttachable : MonoBehaviour
{
    
    [SerializeField] private Transform beesHolder;
    
    private Rigidbody _rb;

    public Rigidbody Rb {
        get {
            if (_rb == null)
                _rb = GetComponent<Rigidbody>();
            
            return _rb;
        }
    }

    public Transform GetBeeHolder() => 
        beesHolder != null ? beesHolder : transform;

}