using UnityEngine;
using YugoA.SceneManagement;

[RequireComponent(typeof(IPlayerGetter))]
public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public SimpleSceneLoader sceneLoader;

    private IPlayerGetter _playerGetter;

    public GameObject Player => _playerGetter.GetPlayer();

    private void Awake()
    {
        Instance = this;

        _playerGetter = GetComponent<IPlayerGetter>();
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