using UnityEngine;

namespace YugoA.SceneManagement
{

    public class SimpleSceneLoader : MonoBehaviour
    {

        public SceneReference sceneRef;

        public void LoadScene()
        {
            SceneLoader.Load(sceneRef);
        }

        public void ReloadThisScene()
        {
            SceneLoader.ReloadThisScene();
        }

    }
    
}