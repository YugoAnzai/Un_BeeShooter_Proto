using UnityEngine;

public class BeeAttachable : MonoBehaviour
{
    
    [SerializeField] private Transform beesHolder;

    public Transform GetBeeHolder() => beesHolder ?? transform;

}