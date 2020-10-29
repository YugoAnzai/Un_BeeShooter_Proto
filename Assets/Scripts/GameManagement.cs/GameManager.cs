using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private GameObject _player;

    public GameObject Player
    {
        get 
        {
            if (_player == null)
                _player = GameObject.FindGameObjectWithTag("Player");
            return _player;
        }
    }

    private void Awake()
    {
        Instance = this;
    }



}