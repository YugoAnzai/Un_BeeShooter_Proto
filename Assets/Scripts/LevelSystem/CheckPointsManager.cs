using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;
using YugoA.Save.PlayerPrefsScriptable;
using System;
using YugoA.SceneManagement;
using YugoA.Helpers;

namespace LevelSystem
{

    public class CheckPointsManager : MonoBehaviour
    {

        [SerializeField] private List<CheckPoint> checkPoints;

        [SerializeField] private SaveKey lastSceneNameKey;
        [SerializeField] private SaveKey lastCheckpointIndexKey;

        private CheckPoint _startingCheckPoint;

        public CheckPoint StartingCheckPoint => _startingCheckPoint;

        private void Awake()
        {

            SetupCheckPoints();

            SaveThisSceneName();

        }

        private void SetupCheckPoints()
        {

            string lastSceneName = PlayerPrefsManager.GetString(lastSceneNameKey);

            int lastIndex = 0;
            if (string.Equals(lastSceneName, SceneLoader.GetActiveScenePath()))
            {
                lastIndex = PlayerPrefsManager.GetInt(lastCheckpointIndexKey);
                LogHelper.Log($"Getting Checkpoint Index: {lastIndex}", Color.green);
            }

            for (int i = 0; i < checkPoints.Count; i++)
            {

                CheckPoint checkPoint = checkPoints[i];

                checkPoint.SetCheckPointsManager(this);
                checkPoint.onCheckPointMarked += CheckPointMarked;

                if (i <= lastIndex)
                {
                    checkPoint.Deactivate();
                }

                if (i == lastIndex)
                {
                    _startingCheckPoint = checkPoint;
                }

            }

        }

        private void SaveThisSceneName()
        {
            
            string scenePath = SceneLoader.GetActiveScenePath();
            PlayerPrefsManager.SetString(lastSceneNameKey, scenePath);
            LogHelper.Log($"Scene Saved {scenePath}", Color.green);

        }

        private void CheckPointMarked(CheckPoint checkPoint)
        {

            int index = checkPoints.IndexOf(checkPoint);
            PlayerPrefsManager.SetInt(lastCheckpointIndexKey, index);
            LogHelper.Log($"Checkpoint Saved {index}", Color.green);

        }

        #region Editor Helpers
        [Button]
        public void FindCheckPoints()
        {
            checkPoints = GameObject.FindObjectsOfType<CheckPoint>().ToList();
        }
        #endregion

    }
    
}