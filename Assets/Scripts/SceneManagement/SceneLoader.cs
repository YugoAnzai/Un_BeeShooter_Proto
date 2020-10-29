using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace YugoA.SceneManagement
{

    public static class SceneLoader
    {

        private class LoadingMonobehaviour : MonoBehaviour {}

        private static Action OnLoaderCallback;
        private static AsyncOperation loadingAsyncOperation;

        private static string _loadingSceneName = "LoadingScene";

        public static void Load(SceneReference sceneRef)
        {
            Load(sceneRef.ScenePath);
        }

        private static void Load(string scenePath)
        {
            OnLoaderCallback = () =>
            {
                GameObject loadinGameObject = new GameObject("Loading Game Object");
                loadinGameObject.AddComponent<LoadingMonobehaviour>().StartCoroutine(LoadSceneAsync(scenePath));
            };

            SceneManager.LoadScene(_loadingSceneName);
        }

        private static IEnumerator LoadSceneAsync(string scenePath)
        {
            yield return null;

            loadingAsyncOperation = SceneManager.LoadSceneAsync(scenePath);

            while (!loadingAsyncOperation.isDone)
            {
                yield return null;
            }
        }

        public static float GetLoadingProgress()
        {
            if (loadingAsyncOperation != null)
            {
                return loadingAsyncOperation.progress;
            }
            else
            {
                return 1;
            }
        }

        public static void LoaderCallback()
        {
            OnLoaderCallback?.Invoke();
            OnLoaderCallback = null;
        }

        public static void ReloadThisScene()
        {
            Scene unityScene = SceneManager.GetActiveScene();
            Load(unityScene.path);
        }

        public static string GetActiveScenePath()
        {
            Scene unityScene = SceneManager.GetActiveScene();
            return unityScene.path;
        }

        #region Additive Scene
        public static void LoadAdditive(SceneReference sceneRef)
        {

            // Check if scene is already loaded
            for (int i = 0; i < SceneManager.sceneCount; i++) {
                Scene unityScene = SceneManager.GetSceneAt(i);
                if (String.Equals(unityScene.path, sceneRef.ScenePath))
                {
                    return;
                }
            }

            SceneManager.LoadScene(sceneRef, LoadSceneMode.Additive);
        }

        public static void UnloadAdditive(SceneReference sceneRef) {
            SceneManager.UnloadSceneAsync(sceneRef);
        }
        #endregion

    }
    
}