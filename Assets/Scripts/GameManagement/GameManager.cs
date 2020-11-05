using System.Collections.Generic;
using UnityEngine;
using YugoA.SceneManagement;

[RequireComponent(typeof(IPlayerGetter))]
public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public SceneReference failScene;
    public SceneReference victoryScene;

    public List<Entity> entitiesToKill;
    public float victoryDelay = 2;

    private IPlayerGetter _playerGetter;

    public GameObject Player => _playerGetter.GetPlayer();

    private int _killedEntitiesCount;
    private int _startingToKillCount;

    private void Awake()
    {
        Instance = this;

        _playerGetter = GetComponent<IPlayerGetter>();
    }

    private void Start()
    {

        Player.GetComponent<PlayerEntity>().onDie += Defeat;

        _startingToKillCount = entitiesToKill.Count;
        foreach(Entity entity in entitiesToKill)
        {
            entity.onDie += OnEntityKilled;
        }

    }

    private void OnEntityKilled(Entity entity)
    {
        
        _killedEntitiesCount++;

        if (_killedEntitiesCount == _startingToKillCount)
        {
            Invoke(nameof(Victory), victoryDelay);
        }

    }

    private void Defeat(Entity entity)
    {
        SceneLoader.Load(failScene);
    }

    private void Victory()
    {
        SceneLoader.Load(victoryScene);
    }

}