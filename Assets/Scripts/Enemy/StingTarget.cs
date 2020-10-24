using System;
using UnityEngine;

public class StingTarget : MonoBehaviour
{

    public Action onStung;

    private bool _isAlive;

    public void Stung()
    {

        _isAlive = false;

        onStung?.Invoke();

        Destroy(gameObject);

    }    

}