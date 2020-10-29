using UnityEngine;
using UnityEngine.Events;
using YugoA.Helpers;

namespace YugoA.SceneManagement
{

    public class LevelSequenceHelper : MonoBehaviour {
        
        public UnityEvent onBeforeLoadNextLevel;

        public void LoadNextLevel() {

            onBeforeLoadNextLevel?.Invoke();

            if (LevelSequenceManager.Instance != null) {
                LevelSequenceManager.Instance.LoadNextLevel();
            } else {
                LogHelper.Log("No Level Sequence Manager");
                SceneLoader.ReloadThisScene();
            }
            
        }

        public void FadeOutLoadNext() {
            FadeInOutPanel fadeInOutPanel = FindObjectOfType<FadeInOutPanel>();

            if (fadeInOutPanel != null) {
                fadeInOutPanel.onFadeOutComplete += LoadNextLevel;
                fadeInOutPanel.FadeOut();
            } else {
                LoadNextLevel();
            }

        }
        
    }

}