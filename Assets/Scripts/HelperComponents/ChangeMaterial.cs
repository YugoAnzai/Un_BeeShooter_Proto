using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{

    public List<MeshRenderer> targetRenderers;
    public Material targetMaterial;

    public void Change()
    {
        foreach(MeshRenderer rend in targetRenderers)
        {
            rend.material = targetMaterial;
        }
    }

}