using UnityEngine;


public class BeeSpreaderParticleController : MonoBehaviour
{

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
    }

}