using System;
using UnityEngine;
using UnityEngine.Events;

namespace LevelSystem
{

    public class CheckPoint : Collectible
    {

        public UnityEvent onDeactivated;

        public Action<CheckPoint> onCheckPointMarked;

        private CheckPointsManager _checkPointsManager;

        public void SetCheckPointsManager(CheckPointsManager checkPointsManager)
        {
            _checkPointsManager = checkPointsManager;
        }

        protected override void Effect()
        {
            onCheckPointMarked?.Invoke(this);
        }

        protected override void AfterEffect()
        {
            Deactivate();
        }

        public void Deactivate()
        {

            _isCollected = true;

            onDeactivated?.Invoke();
            // Change visuals

        }

    }

}