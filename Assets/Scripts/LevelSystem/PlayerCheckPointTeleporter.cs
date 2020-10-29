using UnityEngine;

namespace LevelSystem
{

    public class PlayerCheckPointTeleporter : MonoBehaviour
    {

        private void Start()
        {

            GameObject player = GameManager.Instance.Player;

            CheckPointsManager checkPointsManager = FindObjectOfType<CheckPointsManager>();
            Vector3 startingPos = 
                checkPointsManager.StartingCheckPoint.transform.position;

            player.GetComponent<FPSCharacterController>().Warp(startingPos);

        }

    }

}