using UnityEngine;
using YugoA.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public SimpleSceneLoader sceneLoader;

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

    private void Start()
    {
        Player.GetComponent<PlayerEntity>().onDie += Defeat;
    }

    private void Defeat(Entity entity)
    {
        sceneLoader.ReloadThisScene();
    }

}