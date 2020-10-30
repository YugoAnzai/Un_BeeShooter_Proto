using System;
using UnityEngine;

public class StingTarget : MonoBehaviour
{

    public Action onStung;

    public virtual void Stung()
    {

        onStung?.Invoke();

    }    

}