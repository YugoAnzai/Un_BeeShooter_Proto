using System.Collections.Generic;
using UnityEngine;

namespace YugoA.SceneManagement
{

    public class LevelSequenceManager : MonoBehaviour
    {

        public static LevelSequenceManager Instance;

        [SerializeField]
        private List<SceneReference> levelSequence;
        public List<SceneReference> LevelSequence => levelSequence;

        private int currentLevelIndex;

        private void Awake()
        {

            if (Instance != null)
            {
                Destroy(Instance.gameObject);
            }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }

        public void LoadCurrentScene()
        {
            SceneLoader.Load(levelSequence[currentLevelIndex]);
        }

        public void StartLevelSequenceAndLoad()
        {

            currentLevelIndex = 0;
            LoadCurrentScene();

        }

        public void LoadNextLevel()
        {

            currentLevelIndex++;
            if (currentLevelIndex >= levelSequence.Count)
            {
                Debug.LogWarning("Last level already loaded");
                return;
            }

            LoadCurrentScene();

            if (currentLevelIndex == levelSequence.Count - 1) {
                Destroy(gameObject);
            }

        }

        public void SetLevelIndex(int index) {
            if (index < levelSequence.Count) {
                currentLevelIndex = index;
            } else if (Debug.isDebugBuild) {
                Debug.LogWarning("Trying to set level index greater than level quantity");
            }
        }

        public int GetIndexFromScene(SceneReference sceneRef) {
            return levelSequence.FindIndex( x => x == sceneRef);
        }

    }
    
}